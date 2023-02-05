using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ElementsContainer", menuName = "Containers/ElementsContainer")]
public class ElementsContainer : ScriptableObject
{
    [Serializable]
    public class ElementIDPrefabPair
    {
        public ElementType ElementType;
        public int Amount;
        public GameObject ElementPrefab;
    }

    [SerializeField] private List<ElementIDPrefabPair> elementIDPrefabPairs;  

    public List<ElementIDPrefabPair> GetAllElementIDPrefabPairs()
    {
        return elementIDPrefabPairs;
    }
}
