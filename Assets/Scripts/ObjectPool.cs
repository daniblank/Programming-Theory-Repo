using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(800)]
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count == 0)
        {
            return null;
        }
        Debug.Log("GetPooledObjects:"+pooledObjects.Count);
        for (int i = 0; i < amountToPool; i++)
        {
            Debug.Log("GetPooledObject:" + i);
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
