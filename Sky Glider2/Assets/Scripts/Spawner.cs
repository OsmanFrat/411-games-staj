using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject stick;
    private StickController stickController;
    public GameObject blueCube;
    public Vector3 offset = new Vector3(0, 0, -200);
    public Vector3 spawnPositon;
    void Start()
    {
        stickController = stick.GetComponent<StickController>();
        
    }

    
    void Update()
    {
        if (stickController.playerThrown)
        {
            spawnPositon = new Vector3(0, 0, player.transform.position.z) + offset;
            InvokeRepeating("SpawnObjects", 2f, 1);
        }
    }

    void SpawnObjects()
    {
        Instantiate(blueCube, spawnPositon, Quaternion.identity);
    }

}
