using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    [SerializeField] private SubNodeController subNodeController;
    [SerializeField] private BridgeView _bridgeBefore;
    [SerializeField] private BridgeView _bridgeAfter;

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
