using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameElementsManager : MonoBehaviour
{
    [Serializable]
    public class GameElementsSpawner
    {
        public List<ElementViewBase> elementViews = new List<ElementViewBase>();

        public void SpawnElement(ElementType elementType)
        {
            // TODO: spawn the corresponding element
        }
    }
}
