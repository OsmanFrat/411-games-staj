using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private GameObject bombPrefab;

    public Transform[] spawnPoints;
    public  bool gameOver = false;

    [SerializeField] private float minFruitSpawnDelay = .1f;
    [SerializeField] private float maxFruitSpawnDelay = 1f;

    public float minBombSpawnDelay = 50f;
    public float maxBombSpawnDelay = 100f;
    private void Start()
    {
        StartCoroutine(SpawnFruits());
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnFruits()
    {
        while (!gameOver)
        {
            float delay = Random.Range(minFruitSpawnDelay, maxFruitSpawnDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruits = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            
            Destroy(spawnedFruits, 5f);
        }
    }

    IEnumerator SpawnBomb()
    {
        while (!gameOver)
        {
            float delay = Random.Range(minBombSpawnDelay, maxBombSpawnDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            
            GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
            
            Destroy(spawnedBomb, 5f);
        }
    }
}
