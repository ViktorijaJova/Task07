using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float maxspawnHeight = 15f;
    public float minspawnHeight = 6f;
    public float maxrepeatRate =4f;
    public float minrepeatRate = 0.75f;

    public float spawnHeight;
    public float repeatRate;
    public float timer;

    

    private PlayerControllerX playerControllerScript;

    void Start()
    {
        repeatRate = Random.Range(minrepeatRate, maxrepeatRate);
        spawnHeight = Random.Range(minspawnHeight, maxspawnHeight);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > repeatRate)
        {
            SpawnObjects();
            repeatRate = Random.Range(minrepeatRate, maxrepeatRate);
            spawnHeight = Random.Range(minspawnHeight, maxspawnHeight);
            timer = 0;

        }
    }

    void SpawnObjects ()
    {
     
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnLocation = new Vector3(30, spawnHeight, 0);
            int index = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        
        }

    }
}
