using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float startSpawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float spawnAcceleration = 0.05f; // How fast spawn rate increases

    [Header("Spawn Area")]
    public Transform[] spawnPoints; // Optional spawn points

    private float currentSpawnInterval;
    private float spawnTimer;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return; // Don't spawn when paused

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();

            // Increase spawn rate over time
            currentSpawnInterval -= spawnAcceleration;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);

            spawnTimer = currentSpawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length > 0)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}