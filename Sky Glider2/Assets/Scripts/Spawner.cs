using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject player;
    public GameObject ground;

    [SerializeField] private LaunchController launchController;

    public float width = 800f;   // Width of the rectangle (along the x-axis)
    public float height = 1000f; // Height of the rectangle (along the z-axis)
    public int numberOfObjects = 100;

    private float objectWidth = 30f;
    private float objectDepth = 30f;
    private int rows;
    private int columns;

    private List<Vector3> gridPositions = new List<Vector3>();

    public Vector3 offset = new Vector3(0, 0, 500f);

    public float checkInterval = 1000f;
    private float nextCheckPosition = 0f;

    void Start()
    {
        CreateGrid();
        SpawnObjects();

        launchController = GameObject.Find("Stick").GetComponent<LaunchController>();

        nextCheckPosition = Mathf.Floor(transform.position.z / checkInterval) * checkInterval + checkInterval;
    }

    private void Update()
    {
        if (launchController.playerThrown)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = player.transform.position.z + offset.z;
            transform.position = newPosition;

            if (transform.position.z >= nextCheckPosition && Mathf.Floor(transform.position.z / checkInterval) * checkInterval != 2000f)
            {
                Debug.Log(transform.position.z + " Spawned!");

                CreateGrid();
                SpawnObjects();

                ground.transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y, ground.transform.position.z + 500f);

                nextCheckPosition += checkInterval;
            }
        }
    }

    public void CreateGrid()
    {
        rows = Mathf.FloorToInt(width / (objectWidth + 10f));
        columns = Mathf.FloorToInt(height / (objectDepth + 10f));

        float spawnerZ = transform.position.z;
        Vector3 rectangleMin = transform.position - new Vector3(width / 2, 0f, height / 2);
        Vector3 startPosition = new Vector3(rectangleMin.x + objectWidth / 2, 0f, spawnerZ - height / 2 + objectDepth / 2);

        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < columns; z++)
            {
                Vector3 gridPosition = startPosition + new Vector3(x * (objectWidth + 10f), 0f, z * (objectDepth + 10f));
                gridPositions.Add(gridPosition);
            }
        }
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (gridPositions.Count == 0)
                break;

            int randomIndex = Random.Range(0, gridPositions.Count);
            Vector3 spawnPosition = gridPositions[randomIndex];
            gridPositions.RemoveAt(randomIndex);

            float y = Random.Range(0f, 10f);  // Randomize y position between 0 and 10
            spawnPosition.y = y;

            GameObject prefabToSpawn = Random.value > 0.5f ? prefab1 : prefab2;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
