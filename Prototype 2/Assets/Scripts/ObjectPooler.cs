using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{    
    public GameObject pooledObject;
    public int pooledAmount = 10;
    public bool allowPoolToGrow = true;

    private List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject newObject = (GameObject)Instantiate(pooledObject);
            newObject.SetActive(false);
            pooledObjects.Add(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; ++i)
        {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
             }
        }
        
        if (allowPoolToGrow)
        {
            GameObject newGameObject = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(newGameObject);
        }
        return null;
    }

}
