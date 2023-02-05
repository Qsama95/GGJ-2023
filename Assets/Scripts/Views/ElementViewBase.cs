using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElementViewBase : MonoBehaviour
{
    [SerializeField] private ElementType _elementType;

    private Vector3 _moveDir;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    public Vector3 MoveDir { get => _moveDir; set => _moveDir = value; }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _collider.enabled = true;
        _rigidbody.simulated = true;
    }

    private void OnEnable()
    {
        _collider.enabled = true;
        _rigidbody.simulated = true;

        Invoke(nameof(DisableItSelf), Random.Range(3, 5));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var touchedNode = other.GetComponent<IElementInteractable>();
        if (touchedNode != null)
        {
            touchedNode.OnTouchedElement(_elementType);
            OnTouchedNode();
        }
    }

    private void OnTouchedNode()
    {
        _collider.enabled = false;
        _rigidbody.simulated = false;
        gameObject.SetActive(false);
    }

    private void DisableItSelf()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // TODO: move around in the playground
        transform.DOMove(transform.position + _moveDir * Time.deltaTime, 0.1f);
    }
}
public enum ElementType
{
    Nothing,
    CheckPoint,
    Cutter,
    Splitter,
    Shield,
    Freezer,
    Rewinder,
    Sprouter,
    Devouerer
}
