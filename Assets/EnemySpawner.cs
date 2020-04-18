using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int baseSpawns = 12,
                extraSpawnsPerRound = 6;

    [SerializeField]
    private float spawnRate = 3f,
                  spawnRateChange = 0.2f,
                  spawnRateFloor = 1f,
                  spawnDistanceFromPlayer = 15f;

    private float currentSpawnRate;
    private float spawnTimer;
    [SerializeField]
    private bool doSpawns = true;

    private Transform player => GameObject.FindGameObjectWithTag("Player").transform;

    [SerializeField]
    private GameObject[] Enemies;

    public void LowerSpawnRate() 
        => spawnRate -= (spawnRate > spawnRateFloor) ? spawnRateChange : 0;
    private void StopSpawns() => doSpawns = false;
    private void StartSpawns() => doSpawns = true;


    private void Start()
    {
        currentSpawnRate = spawnRate;
        spawnTimer = spawnRate;
        desiredSpawns = baseSpawns;
    }

    private void Update()
    {
        if (GameStateManager.Instance.GameState == GameState.Shooty)
        {
            HandleWaves();
            Spawning();
        }
    }

    private int waveNumber = 1;
    private int curNumSpawns = 0;
    private int desiredSpawns;
    private void HandleWaves()
    {
        if (curNumSpawns >= desiredSpawns)
        {
            StopSpawns();
            curNumSpawns = 0;
            desiredSpawns += extraSpawnsPerRound;
        }

        if (GameStateManager.Instance.activeEnemies <= 0 && doSpawns == false)
        {
            GameStateManager.Instance.GameState = GameState.Scenario;
            ++waveNumber;
        }
    }
    private void Spawning()
    {
        if (!doSpawns)
            return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
            HandleSpawn();
    }

    private void HandleSpawn()
    {
        var desiredSpawn = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistanceFromPlayer; 
        var hits = Physics2D.BoxCastAll(desiredSpawn, Vector2.one, 0, Vector2.one);

        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("No Spawn"))
                return;
        }

        Instantiate(Enemies[Random.Range(0, Enemies.Length)], desiredSpawn, Quaternion.identity);
        spawnTimer = currentSpawnRate;
        ++curNumSpawns;
        ++GameStateManager.Instance.activeEnemies;
    }
}
