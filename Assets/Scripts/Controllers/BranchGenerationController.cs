using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BranchGenerationController", menuName = "Controllers/BranchGenerationController")]
public class BranchGenerationController : ScriptableObject
{
    public GameObject _bridgePrefab;
    public GameObject _subNodePrefab;

    public void ConstructNewBranch(
        NodeViewBase parentNode)
    {
        // TODO: assign bridge as child to parent node
        var newBridge = Instantiate(
            _bridgePrefab,
            parentNode.transform.position,
            Quaternion.identity);
        newBridge.transform.parent = parentNode.transform;
        var newBridgeView = newBridge.GetComponent<BridgeView>();
        parentNode.SetBridgeAfterThisNode(newBridgeView);

        // TODO: assign child node as children to the end point of bridge
        var newSubNode = Instantiate(
           _subNodePrefab,
           newBridgeView.BridgeEndPoint.position,
           newBridge.transform.rotation);
        newSubNode.transform.parent = newBridgeView.BridgeEndPoint;
        var newSubNodeView = newSubNode.GetComponent<SubNodeView>();
        newSubNodeView.SetBridgeBeforeThisNode(newBridgeView);
    }
}
