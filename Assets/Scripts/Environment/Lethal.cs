using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private float spawnChancePercent = 60;

    private void Start()
    {
        AttemptSpawn();
    }

    private void AttemptSpawn()
    {
        bool shouldSpawn = spawnChancePercent >= Random.Range(0, 100);

        if (!shouldSpawn)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            collision.GetComponent<Player>().Die();
    }
}
