using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    [Header("Node Management")]
    [SerializeField] private SubNodeController subNodeController;
    [SerializeField] private BridgeView _bridgeBefore;
    [SerializeField] private BridgeView _bridgeAfter;
    public BridgeView BridgeAfter { get => _bridgeAfter; set => _bridgeAfter = value; }

    [Header("Score Management")]
    [SerializeField] private PlayerScoreController _scoreController;
    [SerializeField] private int _baseScore;
    [SerializeField] private int _realScore;

    private NodeViewBase[] _parentNodes;
    public NodeViewBase[] ParentNodes { get => _parentNodes; set => _parentNodes = value; }

    private void Start()
    {
        _parentNodes = GetComponentsInParent<NodeViewBase>();
        _realScore = _baseScore * _parentNodes.Length;

        _scoreController?.UpdateScore?.Invoke(_realScore);
    }

    private void OnDestroy()
    {
        _scoreController?.UpdateScore?.Invoke(-_realScore);
    }

    public Transform NodeTransform => transform;

    public void OnPlayerDragging()
    {
        // TODO: facing towards the mouse
        if (SubNodeStatus == SubNodeStatus.Freezed) return;

        _bridgeBefore?.FacingTowardsMouse?.Invoke();
    }

    public void OnPlayerMouseEnter()
    {
        // TODO: highlight the subnode
        GameObject _sprite;
        _sprite = NodeTransform.Find("SubNodeSprite").gameObject;
        _sprite.GetComponent<cakeslice.Outline>().enabled = true;
    }

    public void OnPlayerMouseExit()
    {
        // TODO: unhighlight the subnode
        GameObject _sprite;
        _sprite = NodeTransform.Find("SubNodeSprite").gameObject;
        _sprite.GetComponent<cakeslice.Outline>().enabled = false;
    }

    public void OnTouchedElement(ElementType element)
    {
        // TODO: do some thing after touch the element
        subNodeController.OnTouchedElement(this, element);
        Debug.Log($"touched on element: {element}");
    }

    public override void SetBridgeBeforeThisNode(BridgeView bridge)
    {
        _bridgeBefore = bridge;
    }

    public override void SetBridgeAfterThisNode(BridgeView bridge)
    {
        _bridgeAfter = bridge;
    }


    // TEST ROTATION
    private void Update()
    {
        //_controllableBridge?.FacingTowardsMouse?.Invoke();
    }
}
