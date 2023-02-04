using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    public void FollowingMouse(Vector3 mousePos)
    {
        // TODO: rotate the node bridge along its end point
    }

    public void OnPlayerMouseEnter()
    {
        // TODO: highlight the subnode
    }

    public void OnPlayerMouseExit()
    {
        // TODO: unhighlight the subnode
    }

    public void OnTouchedElement(ElementControllerBase element)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
