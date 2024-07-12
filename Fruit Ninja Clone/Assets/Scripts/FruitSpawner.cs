using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private GameManager gameManager;
    
    public Transform[] spawnPoints;

    [SerializeField] private float minFruitSpawnDelay = .1f;
    [SerializeField] private float maxFruitSpawnDelay = 1f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (!gameManager.gameOver)
        {
            float delay = Random.Range(minFruitSpawnDelay, maxFruitSpawnDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruits = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            
            Destroy(spawnedFruits, 5f);
        }
    }

}
