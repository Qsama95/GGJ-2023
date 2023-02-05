using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementViewBase : MonoBehaviour
{
    [SerializeField] private ElementType _elementType;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

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
    }

    private void Update()
    {
        // TODO: move around in the playground
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
