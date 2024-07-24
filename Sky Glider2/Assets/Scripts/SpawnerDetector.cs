using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDetector : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    public GameObject ground;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawner"))
        {
            Debug.Log("Spawner Detected!");

            spawner.CreateGrid();
            spawner.SpawnObjects();

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1000f);

            ground.transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y, ground.transform.position.z + 500f);
        }
    }

}
