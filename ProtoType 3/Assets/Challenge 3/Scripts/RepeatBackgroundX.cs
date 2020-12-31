using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startsPosition;
    private float repeatWidth = 50;

    void Start()
    {
        startsPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 5;
    }

    void Update()
    {
        if (transform.position.x < startsPosition.x - repeatWidth)
        {
            transform.position = startsPosition;
        }
    }
    }

 



