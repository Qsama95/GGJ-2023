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
        transform.Rotate(0, 0, transform.eulerAngles.z + Random.Range(-90, 90));
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

    private void OnFacingTowardsMouse()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var targetDir = mousePos - _bridgeStartPoint.position;
        var targetAngle = Vector2.SignedAngle(transform.up, targetDir);
        transform.Rotate(0, 0, targetAngle);
    }
}
