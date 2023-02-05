using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "SubNodeController", menuName = "Controllers/SubNodeController")]
public class SubNodeController : ScriptableObject
{
    [SerializeField] private BranchGenerationController _branchGenerationController;

    public void OnTouchedCheckPoint(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:

                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:

                break;
            case SubNodeStatus.Shielded:

                break;
        }
    }

    public void OnTouchedFreezer(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:

                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:

                break;
            case SubNodeStatus.Shielded:

                break;
        }
    }

    public void OnTouchedSplitter(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:

                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:

                break;
            case SubNodeStatus.Shielded:

                break;
        }
    }

    public void OnTouchedDevouere(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:

                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:

                break;
            case SubNodeStatus.Shielded:

                break;
        }
    }
}

public enum SubNodeStatus
{
    Free,
    Saved,
    Freezed,
    Shielded
}
