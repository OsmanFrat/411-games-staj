using System.Collections;
using UnityEngine;

public class GoldenWatermelonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldenWatermelonPrefab;
    [SerializeField] private GameManager gameManager;

    public Transform[] spawnPoints;

    public float minGoldenwatermelonSpawnDelay = 50f;
    public float maxGoldenwatermelonSpawnDelay = 100f;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(SpawnGoldenWatermelon());
    }


    IEnumerator SpawnGoldenWatermelon()
    {
        while (!gameManager.gameOver)
        {
            float delay = Random.Range(minGoldenwatermelonSpawnDelay, maxGoldenwatermelonSpawnDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];


            GameObject spawnedGoldenWatermelon = Instantiate(goldenWatermelonPrefab, spawnPoint.position, spawnPoint.rotation);

            Destroy(spawnedGoldenWatermelon, 5f);
        }
    }
}
