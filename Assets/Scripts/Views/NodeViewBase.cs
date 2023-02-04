using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeViewBase : MonoBehaviour
{
    public abstract void SetBridgeBeforeThisNode(BridgeView bridge);
    public abstract void SetBridgeAfterThisNode(BridgeView bridge);
}
