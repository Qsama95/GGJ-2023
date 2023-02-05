using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeViewBase : MonoBehaviour
{
    private SubNodeStatus _subNodeStatus;
    public SubNodeStatus SubNodeStatus { get => _subNodeStatus; set => _subNodeStatus = value; }

    public abstract void SetBridgeBeforeThisNode(BridgeView bridge);
    public abstract void SetBridgeAfterThisNode(BridgeView bridge);
}
