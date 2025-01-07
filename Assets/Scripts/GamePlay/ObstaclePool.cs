using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject obstaclePrefab;
        public int size;
    }

    public static ObstaclePool Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public List<Pool> pools;
    private Dictionary<GameObject, Queue<GameObject>> _poolDictionary;

    void Start()
    {
        _poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> pbstaclePool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.obstaclePrefab);
                obj.SetActive(false);
                pbstaclePool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.obstaclePrefab, pbstaclePool);
        }
    }

    public GameObject SpawnFromPool(GameObject obstaclePrefab, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(obstaclePrefab)) return null;
        
        GameObject objectToSpawn = _poolDictionary[obstaclePrefab].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        _poolDictionary[obstaclePrefab].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
