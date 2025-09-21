using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform References")]
    [SerializeField] private Transform[] platformPrefabs;

    [Header("Spawn")]
    [SerializeField] private Vector3 nextSpawnPosition;
    [SerializeField] private float spawnDistanceThreshold;
    [SerializeField] private float despawnDistanceThreshold;

    [Header("Player Reference")]
    [SerializeField] private Transform player;

    private void Update()
    {
        DespawnDistantPlatforms();
        SpawnPlatformsAsNeeded();
    }

    private void SpawnPlatformsAsNeeded()
    {
        while (Vector2.Distance(player.transform.position, nextSpawnPosition) < spawnDistanceThreshold)
        {
            Transform platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

            Vector2 spawnPosition = new Vector2(nextSpawnPosition.x - platformPrefab.Find("Start Point").position.x, 0);

            Transform newPlatform = Instantiate(platformPrefab, spawnPosition, transform.rotation, transform);
            nextSpawnPosition = newPlatform.Find("End Point").position;
        }
    }

    private void DespawnDistantPlatforms()
    {
        if (transform.childCount > 0)
        {
            Transform platformToRemove = transform.GetChild(0);

            if (Vector2.Distance(player.transform.position, platformToRemove.transform.position) > despawnDistanceThreshold)
                Destroy(platformToRemove.gameObject);
        }
    }
}
