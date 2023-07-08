using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyTypes;
    int spawnPoints;
    public int amountToSpawn = 1;
    public float spawnTimer = 10f;
    public float spawnStart = 15f;
    void Start()
    {
        spawnPoints = transform.childCount;

        InvokeRepeating(nameof(StartWave), spawnStart, spawnTimer);
    }

    void StartWave()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            int spawnPoint = Random.Range(0, spawnPoints);
            int enemyType = Random.Range(0, enemyTypes.Length);
            Instantiate(enemyTypes[enemyType], transform.GetChild(spawnPoint).position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        amountToSpawn++;
    }
}
