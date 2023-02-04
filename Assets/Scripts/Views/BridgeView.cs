using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BridgeView : MonoBehaviour
{
    [SerializeField] private Transform _bridgeStartPoint;
    [SerializeField] private Transform _bridgeEndPoint;

    private Transform _startFromNode;
    private Transform _endAtNode;

    public Transform StartFromNode { get => _startFromNode; set => _startFromNode = value; }
    public Transform EndAtNode { get => _endAtNode; set => _endAtNode = value; }

    void Start()
    {
        
    }
    private void Update()
    {
        OnRotateTowardMouse();
    }

    private void OnRotateTowardMouse()
    {
        var targetDir = Input.mousePosition - _bridgeEndPoint.position;
        var targetAngle = Vector3.SignedAngle(transform.up, targetDir, -transform.forward);
        transform.RotateAround(_bridgeEndPoint.position, -transform.forward, targetAngle);
    }
}
