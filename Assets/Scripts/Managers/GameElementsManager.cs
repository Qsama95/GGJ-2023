using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameElementsManager : MonoBehaviour
{
    [Serializable]
    public class GameElementsSpawner
    {
        public void SpawnElement(GameObject elementObj)
        {
            // TODO: spawn the corresponding element
            //switch (elementType)
            //{
            //    case ElementType.CheckPoint:

            //        break;
            //    case ElementType.Cutter:

            //        break;
            //    case ElementType.Devouerer:

            //        break;
            //    case ElementType.Freezer:

            //        break;
            //    case ElementType.Splitter:

            //        break;
            //    case ElementType.Rewinder:

            //        break;
            //    case ElementType.Shield:

            //        break;
            //    case ElementType.Sprouter:

            //        break;

            //}
            var randomPosOutFromCircle = Random.insideUnitSphere * 20;
            randomPosOutFromCircle.z = 0;
            elementObj.transform.position = randomPosOutFromCircle;

            elementObj.GetComponent<ElementViewBase>().MoveDir =
                 Vector3.zero - elementObj.transform.position;
            elementObj.SetActive(true);
        }
    }

    [SerializeField] private ElementsContainer _elementsContainer;
    private List<GameObject> _spawnedElements = new List<GameObject>();
    private GameElementsSpawner _elementSpawner;

    private void Start()
    {
        _elementSpawner = new GameElementsSpawner();

        Init();
        InvokeRepeating(nameof(SpawnElementRandomly), 3, Random.Range(0.5f, 1));
    }

    private void Init()
    {
        // spawn all elements and save them
        foreach (ElementsContainer.ElementIDPrefabPair pair in _elementsContainer.GetAllElementIDPrefabPairs())
        {
            var newElement = Instantiate(pair.ElementPrefab);
            newElement.SetActive(false);
            _spawnedElements.Add(newElement);
        }
    }

    private void SpawnElementRandomly()
    {
        var randomIndex = Random.Range(0, _spawnedElements.Count - 1);
        if (_spawnedElements[randomIndex].activeSelf) return;
        _elementSpawner.SpawnElement(_spawnedElements[randomIndex]);
    }
}
