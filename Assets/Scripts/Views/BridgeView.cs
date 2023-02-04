using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
