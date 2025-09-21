using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private int coinsToSpawn;

    [Header("Coin Prefab")]
    [SerializeField] private GameObject coinPrefab;

    [Header("Coin Spawn Amount")]
    [SerializeField] private int minCoinsToSpawn;
    [SerializeField] private int maxCoinsToSpawn;

    [Header("Coin Spacing")]
    [SerializeField] private float coinSpacing = 2.0f;

    void Start()
    {
        coinsToSpawn = Random.Range(minCoinsToSpawn, maxCoinsToSpawn);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            Vector3 offset = new Vector2(i * coinSpacing, 0);
            Instantiate(coinPrefab, transform.position + offset, Quaternion.identity, transform);
        }   
    }
}
