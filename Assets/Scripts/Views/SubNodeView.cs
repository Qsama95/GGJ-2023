using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    [Header("Node Management")]
    [SerializeField] private SubNodeController subNodeController;
    [SerializeField] private BridgeView _bridgeBefore;
    [SerializeField] private BridgeView _bridgeAfter;

    [Header("Score Management")]
    [SerializeField] private PlayerScoreController _scoreController;
    [SerializeField] private int _baseScore;
    [SerializeField] private int _realScore;

    private SubNodeStatus _subNodeStatus;
    private NodeViewBase[] _parentNodes;
    public SubNodeStatus SubNodeStatus { get => _subNodeStatus; set => _subNodeStatus = value; }
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
        _bridgeBefore?.FacingTowardsMouse?.Invoke();
    }

    public void OnPlayerMouseEnter()
    {
        // TODO: highlight the subnode
    }

    public void OnPlayerMouseExit()
    {
        // TODO: unhighlight the subnode
    }

    public void OnTouchedElement(ElementType element)
    {
        // TODO: do some thing after touch the element
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
