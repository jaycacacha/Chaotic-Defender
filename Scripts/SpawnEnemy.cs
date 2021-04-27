using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    private int randomSpawnPoint;
    public float spawnTime;
    private Transform targetPlayer;

    bool enemySpawn;
    public static bool SpawnWave;
    void Start()
    {
        SpawnWave = true;
        spawnTime = 0.96f;
        // targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(EnemyWave());

    }
    void spawnEnemy()
    {
        if (SpawnWave == true)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].position, transform.rotation);
        }
    }
    IEnumerator EnemyWave()
    {
        while (SpawnWave == true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnEnemy();
        }
    }
}
