using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private Transform lastSpawnedPlatformPrefab = null;
    private bool firstPlatformSpawned = false;

    [Header("Platform References")]
    [SerializeField] private Transform[] platformPrefabs; // Array of platform prefabs to choose from
    [SerializeField] private Transform firstPlatformPrefab; // The first platform to spawn

    [Header("Spawn")]
    public Vector3 nextSpawnPosition; // Position where the next platform should be spawned
    [SerializeField] private float spawnDistanceThreshold; // Distance at which new platforms are spawned
    [SerializeField] private float despawnDistanceThreshold; // Distance at which old platforms are removed

    [Header("Player Reference")]
    [SerializeField] private Transform player;


    private void Update()
    {
        DespawnDistantPlatforms();
        SpawnPlatformsAsNeeded();
    }

    // Spawns the first platform at the origin
    public Transform SpawnFirstPlatform()
    {
        Transform newPlatform = Instantiate(firstPlatformPrefab, Vector3.zero, Quaternion.identity, transform);
        nextSpawnPosition = newPlatform.Find("End Point").position; // Set where the next platform should spawn
        lastSpawnedPlatformPrefab = firstPlatformPrefab; 
        firstPlatformSpawned = true;
        return newPlatform;
    }

    // Spawns additional platforms based on player position
    private void SpawnPlatformsAsNeeded()
    {
        if (!firstPlatformSpawned)
            return;

        // Keep spawning while the player is near the next spawn point
        while (Vector2.Distance(player.position, nextSpawnPosition) < spawnDistanceThreshold)
        {
            Transform platformPrefab;

            // Ensure the new platform is not the same as the last one
            do
            {
                platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            }
            while (platformPrefab == lastSpawnedPlatformPrefab);

            // Calculate the correct spawn position using the platform's Start Point
            Transform startPoint = platformPrefab.Find("Start Point");
            Vector2 localOffset = startPoint.localPosition;
            Vector2 spawnPosition = nextSpawnPosition - (Vector3)localOffset;

            // Instantiate and place the new platform
            Transform newPlatform = Instantiate(platformPrefab, spawnPosition, transform.rotation, transform);
            nextSpawnPosition = newPlatform.Find("End Point").position; // Update for the next spawn

            lastSpawnedPlatformPrefab = platformPrefab;
        }
    }

    // Removes the oldest platform if it is too far behind the player
    private void DespawnDistantPlatforms()
    {
        if (transform.childCount > 0)
        {
            Transform platformToRemove = transform.GetChild(0);

            if (Vector2.Distance(player.position, platformToRemove.position) > despawnDistanceThreshold)
                Destroy(platformToRemove.gameObject);
        }
    }
}
