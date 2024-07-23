using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDetector : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

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
        }
    }

}
