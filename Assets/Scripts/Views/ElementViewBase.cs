using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementViewBase : MonoBehaviour
{
    [SerializeField] private ElementType _elementType;
}
public enum ElementType
{
    Cutter,
    Grower
}
