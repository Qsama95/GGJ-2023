using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementViewBase : MonoBehaviour
{
    [SerializeField] private ElementType _elementType;

    private void OnTriggerEnter(Collider other)
    {
        var touchedNode = other.GetComponent<IElementInteractable>();
        if (touchedNode != null)
        {
            touchedNode.OnTouchedElement(_elementType);
        }
    }

    private void Update()
    {
        // TODO: move around in the playground
    }
}
public enum ElementType
{
    Nothing,
    Cutter,
    Grower,
    Shielder,
    Freezer
}
