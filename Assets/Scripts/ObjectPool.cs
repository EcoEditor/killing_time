using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int initialCapacity;
    
    private static GameObject _pooledObjectPrefab;
    private static List<GameObject> _pool;

    /// <summary>
    /// Initialize the pool on awake
    /// </summary>
    private void Awake()
    {
        _pool = new List<GameObject>(new GameObject[initialCapacity]);
        
        for (int i = 0; i < initialCapacity; i++)
        {
            var objectToPool = GetNewObject();
            _pool[i] = objectToPool;
        }
    }

    /// <summary>
    /// Gets a pool object from the pool
    /// </summary>
    /// <returns>bullet</returns>
    public static GameObject GetPoolObject()
    {
        // replace code below with correct code
        if (_pool.Count > 0)
        {
            GameObject pooledObject = _pool[_pool.Count - 1];
            _pool.RemoveAt(_pool.Count - 1);
            return pooledObject;
        }
        
        _pool.Capacity++;
        return GetNewObject();
    }


    /// <summary>
    /// Returns a pooled object to the pool
    /// </summary>
    public static void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Add(obj);
    }

    /// <summary>
    /// Gets a new object
    /// </summary>
    /// <returns>new object</returns>
    private static GameObject GetNewObject()
    {
        GameObject obj;
        obj = Instantiate(_pooledObjectPrefab);
        obj.SetActive(false);
        DontDestroyOnLoad(obj);
        return obj;
    }

    /// <summary>
    /// Returns all the pooled objects from the object pool
    /// </summary>
    public static void ReturnAll()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            ReturnObject(_pool[i]);
        }
    }
}