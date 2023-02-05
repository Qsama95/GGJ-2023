using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private BranchGenerationController _branchGenerationController;
    [Space]
    [SerializeField] private LayerMask _subNodeLayer;
    private RaycastHit2D _hit = new RaycastHit2D();

    private RootNodeView _rootNode;
    private IDraggable _selectedNode;
    private IDraggable _highlightedNode;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        _rootNode = FindObjectOfType<RootNodeView>();
        _branchGenerationController?.ConstructNewBranch(
                    _rootNode.transform.GetComponent<NodeViewBase>());
    }

    void Update()
    {
        DetectRotationInput();
        DetectSubNode();
        DetectSelectSubNode();
    }

    private void DetectRotationInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // rotate root node counter clockwise
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // rotate root node clockwise
        }
    }

    private void DetectSubNode()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Does the ray intersect with subnode
        _hit = Physics2D.GetRayIntersection(ray, _subNodeLayer);
        if (_hit)
        {
            Debug.Log($"hit on subnode: " +
                $"{_hit.transform.GetComponent<IDraggable>()}");
            // TODO: call mouse enter method on the subnode
            // TODO: assign highlighted node in this manager
            if (_selectedNode != null) return;
            _highlightedNode = _hit.transform.GetComponent<IDraggable>();
            _highlightedNode?.OnPlayerMouseEnter();
        }
        else
        {
            Debug.Log("did not hit on subnode");
            // TODO: call mouse exit method on the subnode
            // TODO: remove highlighted node in this manager
            if (_highlightedNode == null) return;
            _highlightedNode?.OnPlayerMouseExit();
            _highlightedNode = null;
        }
    }

    private void DetectSelectSubNode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: if there is a highlighted node, select the highlighted node
            if (_highlightedNode != null)
            {
                Debug.Log("select the highlighted node");
                _selectedNode = _highlightedNode;
                _highlightedNode = null;
            }
        }
        if (Input.GetMouseButton(0))
        {
            // TODO: if there is a highlighted node, select the highlighted node
            if (_selectedNode != null)
            {
                Debug.Log("dragging the selected node");
                _selectedNode?.OnPlayerDragging();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // TODO: release the selected node
            if (_selectedNode != null)
            {
                Debug.Log("release the selected node");
                _selectedNode = null;
            }
        }

        // TEST: press space to generate branches, should be replaced by element interaction
        if (_highlightedNode != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("generate a new branch");
                _branchGenerationController?.ConstructNewBranch(
                    _highlightedNode.NodeTransform.GetComponent<NodeViewBase>());
            }
        }       
    }

}
