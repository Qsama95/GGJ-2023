using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "SubNodeController", menuName = "Controllers/SubNodeController")]
public class SubNodeController : ScriptableObject
{
    public void OnTouchedCheckPoint(SubNodeView subNode)
    {
        // TODO: 
    }

    public void OnTouchedFreezer(SubNodeView subNode)
    {
        // TODO: 
    }

    public void OnTouchedSplitter(SubNodeView subNode)
    {
        // TODO: 
    }

    public void OnTouchedDevouere(SubNodeView subNode)
    {
        // TODO: 
    }
}

public enum SubNodeStatus
{
    Free,
    Freezed,
    Shielded
}
