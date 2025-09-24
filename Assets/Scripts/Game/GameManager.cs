using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    [Header("References")]
    [SerializeField] private PlatformSpawner platformSpawner;

    public int coins;

    private void Awake()
    {
        instance = this; // Set the singleton instance
    }

    private void Start()
    {
        platformSpawner.SpawnFirstPlatform(); // Spawn the first platform when the game begins
    }

    // Reloads the current scene to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
