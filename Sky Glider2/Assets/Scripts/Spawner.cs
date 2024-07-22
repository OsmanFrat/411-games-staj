using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject player;
    public float spawnDistance = 20.0f;
    public float spawnInterval = 5.0f;
    public float sideOffset = 3.0f;
    public float groundY = 0.5f;
    public float destroyTime = 2.0f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.transform.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.transform.position.z > nextSpawnZ - spawnDistance)
        {
            SpawnCubes();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnCubes()
    {

        int randomPrefabIndex = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[randomPrefabIndex];


        int randomPosition = Random.Range(0, 3); // 0 = orta, 1 = sað, 2 = sol

        Vector3 spawnPosition = new Vector3(player.transform.position.x, groundY, nextSpawnZ);

        if (randomPosition == 1)
        {
            spawnPosition += player.transform.right * sideOffset;
        }
        else if (randomPosition == 2)
        {
            spawnPosition -= player.transform.right * sideOffset;
        }

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        Destroy(spawnedObject, destroyTime);
    }
}