using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [Header("Game Object:")]
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private GameObject _obWallPrefab;

    [Header("Conditions:")]
    [SerializeField] private float spawnInterval;

    [SerializeField] private float spawnObstaclePosY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), 0f, spawnInterval);
    }

    private void SpawnRandomObstacle()
    {
        GameObject randomPrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
        float randomX;

        if(randomPrefab == _obWallPrefab)
        {
            randomX = Random.value < 0.5f ? minX : maxX;
        }
        else
        {
            randomX = Random.Range(minX, maxX);
        }

        Vector3 spawnPosition = new Vector3(randomX, spawnObstaclePosY, 0);

        ObstaclePool.Instance.SpawnFromPool(randomPrefab, spawnPosition, Quaternion.identity);
    }
}
