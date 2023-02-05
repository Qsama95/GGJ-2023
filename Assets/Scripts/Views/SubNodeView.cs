using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SubNodeView : NodeViewBase, IDraggable, IElementInteractable
{
    [Header("Node Management")]
    [SerializeField] private SubNodeController subNodeController;
    [SerializeField] private BridgeView _bridgeBefore;
    [SerializeField] private BridgeView _bridgeAfter;

    [Header("Score Management")]
    [SerializeField] private PlayerScoreController _scoreController;
    [SerializeField] private int _baseScore;
    [SerializeField] private int _realScore;

    NodeViewBase[] _parentNodes;

    private void Start()
    {
        _parentNodes = GetComponentsInParent<NodeViewBase>();
        _realScore = _baseScore * _parentNodes.Length;
    }

    public Transform NodeTransform => transform;

    public void OnPlayerDragging()
    {
        // TODO: facing towards the mouse
        _bridgeBefore?.FacingTowardsMouse?.Invoke();
    }

    public void OnPlayerMouseEnter()
    {
        // TODO: highlight the subnode
        GameObject _sprite;
        _sprite = NodeTransform.Find("SubNodeSprite").gameObject;
        _sprite.GetComponent<cakeslice.Outline>().enabled = true;

        //Enable lighting
        //Bloom bloomLayer;
        //PostProcessVolume volume = _sprite.GetComponent<PostProcessVolume>();
        //volume.profile.TryGetSettings(out bloomLayer);
        //Debug.Log(bloomLayer.enabled.value);
        //bloomLayer.enabled.value = true;
        //Debug.Log(bloomLayer.enabled.value);
    }

    public void OnPlayerMouseExit()
    {
        // TODO: unhighlight the subnode
        GameObject _sprite;
        _sprite = NodeTransform.Find("SubNodeSprite").gameObject;
        _sprite.GetComponent<cakeslice.Outline>().enabled = false;
    }

    public void OnTouchedElement(ElementType element)
    {
        // TODO: do some thing after touch the element
    }

    public override void SetBridgeBeforeThisNode(BridgeView bridge)
    {
        _bridgeBefore = bridge;
    }

    public override void SetBridgeAfterThisNode(BridgeView bridge)
    {
        _bridgeAfter = bridge;
    }


    // TEST ROTATION
    private void Update()
    {
        //_controllableBridge?.FacingTowardsMouse?.Invoke();
    }
}
