using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacleprefab;
    private Vector3 spawnposition= new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playercontrollerScripts;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
       playercontrollerScripts = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playercontrollerScripts.gameOver == false)
        {
            Instantiate(obstacleprefab, spawnposition, obstacleprefab.transform.rotation);
        }


    }
}
