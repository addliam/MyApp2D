using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    // Public GameObject array to hold multiple enemy prefabs
    public GameObject[] EnemyPrefabs;

    // Delay for spawning enemies
    float maxSpawnRateInSeconds = 5f;

    // Start is called once at the beginning
    void Start()
    {
        // Invoke the SpawnEnemy function after a delay
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        // Increase spawn rate every 10 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    // Function to spawn an enemy
    void SpawnEnemy()
    {
        // Calculate bottom-left of the screen in world coordinates
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Calculate top-right of the screen in world coordinates
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Select a random enemy prefab from the list
        GameObject randomEnemy = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];

        // Instantiate the randomly selected enemy prefab
        GameObject anEnemy = (GameObject)Instantiate(randomEnemy);

        // Randomly position the enemy at the top of the screen (X random, Y fixed)
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        // Schedule when to spawn the next enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnINSeconds;

        // If maxSpawnRateInSeconds > 1, randomly pick a delay between 1 and maxSpawnRateInSeconds
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnINSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnINSeconds = 1f; // Ensure minimum delay of 1 second
        }

        // Schedule the SpawnEnemy function to execute after spawnINSeconds
        Invoke("SpawnEnemy", spawnINSeconds);
    }

    // Function to increase the difficulty of the game by reducing spawn intervals
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--; // Reduce maxSpawnRateInSeconds by 1
        }

        // Stop increasing difficulty if maxSpawnRateInSeconds reaches 1
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
