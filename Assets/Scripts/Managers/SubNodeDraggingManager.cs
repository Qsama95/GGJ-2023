using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeDraggingManager : MonoBehaviour
{
    [SerializeField] private LayerMask _subNodeLayer;
    private RaycastHit2D _hit = new RaycastHit2D();

    private SubNodeView _selectedNode;
    private SubNodeView _highlightedNode;

    void Start()
    {
        
    }

    void Update()
    {
        DetectSubNode();
        DetectSelectSubNode();
    }

    private void DetectSubNode()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Does the ray intersect with subnode
        _hit = Physics2D.GetRayIntersection(ray, _subNodeLayer);
        if (_hit)
        {
            Debug.Log($"hit on subnode: {_hit.transform.GetComponent<IDraggable>()}");
            // TODO: call mouse enter method on the subnode
            // TODO: assign highlighted node in this manager
        }
        else
        {
            Debug.Log("did not hit on subnode");
            // TODO: call mouse exit method on the subnode
            // TODO: remove highlighted node in this manager
        }
    }

    private void DetectSelectSubNode()
    {
        if (Input.GetMouseButton(0))
        {
            // TODO: if there is a highlighted node, select the highlighted node
            if (_highlightedNode)
            {
                Debug.Log("dragging the selected node");
                _selectedNode = _highlightedNode;
                _highlightedNode = null;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // TODO: release the selected node
            if (_selectedNode)
            {
                Debug.Log("release the selected node");
                _selectedNode = null;
            }
        }
    }

}
