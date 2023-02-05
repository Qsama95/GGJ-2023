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
            switch (elementType)
            {
                case ElementType.CheckPoint:

                    break;
                case ElementType.Cutter:

                    break;
                case ElementType.Devouerer:

                    break;
                case ElementType.Freezer:

                    break;
                case ElementType.Splitter:

                    break;
                case ElementType.Rewinder:

                    break;
                case ElementType.Shield:

                    break;
                case ElementType.Sprouter:

                    break;

            }
        }
    }
}
