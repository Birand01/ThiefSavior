using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolBase : MonoBehaviour
{
    [SerializeField] protected GameObject objectToPool;
    [SerializeField] protected int poolSize = 10;
    protected Queue<GameObject> objectPool;
    public Transform spawnedObjectParent;
    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }
    public virtual void Inýtýalize(GameObject objectToPool, int poolSize = 10)
    {
        this.objectToPool = objectToPool;
        this.poolSize = poolSize;
    }
    public virtual GameObject CreateObject(Transform position)
    {
        CreateObjectParentIfNeeded();
        GameObject spawnedObject = null;
        if (objectPool.Count < poolSize)
        {
            spawnedObject = Instantiate(objectToPool, position.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + " _ " + objectToPool.name + " _ " + objectPool.Count;
            spawnedObject.transform.SetParent(spawnedObjectParent);
        }
        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = position.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }
        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectParent == null)
        {
            string name = "ObjectPool_ " + objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spawnedObjectParent = parentObject.transform;
            }
            else
            {
                spawnedObjectParent = new GameObject(name).transform;
            }
        }
    }
}
