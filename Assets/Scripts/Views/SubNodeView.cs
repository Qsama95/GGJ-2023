using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    [SerializeField] private BridgeView _controllableBridge;

    public BridgeView ControllableBridge { get => _controllableBridge; set => _controllableBridge = value; }

    public Transform NodeTransform => transform;

    public void OnPlayerDragging()
    {
        // TODO: facing towards the mouse
        _controllableBridge?.FacingTowardsMouse?.Invoke();
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

    // TEST ROTATION
    private void Update()
    {
        //_controllableBridge?.FacingTowardsMouse?.Invoke();
    }
}
