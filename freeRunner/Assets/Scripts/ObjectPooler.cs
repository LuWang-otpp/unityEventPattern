using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledAmount;

    private List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject newObj = Instantiate(pooledObject);
            newObj.SetActive(false);
            pooledObjects.Add(newObj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject newObj = Instantiate(pooledObject);
        pooledObjects.Add(newObj);

        pooledAmount++;

        return newObj;
    }
}
