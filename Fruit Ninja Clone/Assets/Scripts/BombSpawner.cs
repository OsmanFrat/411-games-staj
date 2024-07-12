using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameManager gameManager;

    public Transform[] spawnPoints;

    public float minBombSpawnDelay = 50f;
    public float maxBombSpawnDelay = 100f;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(SpawnBomb());
    }


    IEnumerator SpawnBomb()
    {
        while (!gameManager.gameOver)
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
