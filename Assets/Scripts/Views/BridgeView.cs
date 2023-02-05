using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class BridgeView : MonoBehaviour
{
    [SerializeField] private Transform _bridgeStartPoint;
    [SerializeField] private Transform _bridgeEndPoint;

    public Action FacingTowardsMouse;

    public Transform BridgeEndPoint { get => _bridgeEndPoint; set => _bridgeEndPoint = value; }

    private Vector3 _initialScale;

    private void Awake()
    {
        RegisterListeners();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // TEST: start with random rotation
        var growDir = (_bridgeEndPoint.position - Vector3.zero).normalized;
        var randomVecFactor = Random.onUnitSphere;
        randomVecFactor.z = 0;
        RotateTowardsDirection(growDir + randomVecFactor);
        
        _initialScale = transform.localScale;
        GrowUp();
    }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        FacingTowardsMouse += OnFacingTowardsMouse;
    }

    private void UnregisterListeners()
    {
        FacingTowardsMouse -= OnFacingTowardsMouse;
    }

    private void Update()
    {
    }

    private void GrowUp()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(_initialScale, 0.5f);
    }

    private void RotateTowardsDirection(Vector3 targetDir)
    {
        var targetAngle = Vector2.SignedAngle(transform.up, targetDir);
        transform.Rotate(0, 0, targetAngle);
    }

    private void OnFacingTowardsMouse()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var targetDir = mousePos - _bridgeStartPoint.position;
        RotateTowardsDirection(targetDir);
    }
}
