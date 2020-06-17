﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private string currentState = "patrol";
    public float speed = 5;
    private Transform nextWaypoint;
    public Transform waypoint1;
    public Transform waypoint2;
    public float range = 1;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == "patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime);
            transform.position = nextPosition;
            //transform.up = transform.position - ((Vector3)nextPosition);
            if(transform.position == nextWaypoint.position)
            {
                if(nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                } 
                else
                {
                    nextWaypoint = waypoint1;
                }
            }
            if (TargetAquired())
            {
                currentState = "attack";
            }
        }
        else if(currentState == "attack")
        {

            if (!TargetAquired())
            {
                currentState = "patrol";
            }
        }
        
    }

    bool TargetAquired()
    {
        GameObject targetGo = GameObject.FindGameObjectWithTag("Player");
        bool inRange = false;
        bool inVision = false;
        if(Vector2.Distance(targetGo.transform.position, transform.position) < range)
        {
            inRange = true;
        }
        var lineCast = Physics2D.Linecast(transform.position, targetGo.transform.position, mask);
        if (lineCast.transform == null)
        {
            inVision = true;

        }

        return inRange && inVision;
    }
}
