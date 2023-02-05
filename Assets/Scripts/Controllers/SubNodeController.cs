using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "SubNodeController", menuName = "Controllers/SubNodeController")]
public class SubNodeController : ScriptableObject
{
    [SerializeField] private BranchGenerationController _branchGenerationController;
    [SerializeField] private GameAudioController _gameAudioController;

    public void OnTouchedElement(
        SubNodeView subNode,
        ElementType elementType)
    {
        // TODO: 
        switch (elementType)
        {
            case ElementType.Nothing:
                break;
            case ElementType.CheckPoint:
                OnTouchedCheckPoint(subNode);

                break;
            case ElementType.Cutter:

                break;
            case ElementType.Devouerer:
                OnTouchedDevouere(subNode);

                break;
            case ElementType.Freezer:
                OnTouchedFreezer(subNode);

                break;
            case ElementType.Splitter:
                OnTouchedSplitter(subNode);

                break;
            case ElementType.Rewinder:

                break;
            case ElementType.Shield:

                break;
            case ElementType.Sprouter:

                break;
        }
    }
    
    private void OnTouchedCheckPoint(SubNodeView subNode)
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

    private void OnTouchedFreezer(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:
                subNode.SubNodeStatus = SubNodeStatus.Freezed;
                
                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:
                subNode.SubNodeStatus = SubNodeStatus.Freezed;

                break;
            case SubNodeStatus.Shielded:

                break;
        }
    }

    private void OnTouchedSplitter(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:
                _branchGenerationController.ConstructNewBranch(subNode);
                _branchGenerationController.ConstructNewBranch(subNode);
                _gameAudioController.PlayAudio?.Invoke("touch splitter");

                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:

                break;
            case SubNodeStatus.Shielded:
                _branchGenerationController.ConstructNewBranch(subNode);
                _branchGenerationController.ConstructNewBranch(subNode);
                _gameAudioController.PlayAudio?.Invoke("touch splitter");

                break;
        }
    }

    private void OnTouchedDevouere(SubNodeView subNode)
    {
        // TODO: 
        switch (subNode.SubNodeStatus)
        {
            case SubNodeStatus.Free:
                subNode.BridgeAfter.transform.SetParent(null);
                
                break;
            case SubNodeStatus.Saved:

                break;
            case SubNodeStatus.Freezed:
                subNode.BridgeAfter.transform.SetParent(null);

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
