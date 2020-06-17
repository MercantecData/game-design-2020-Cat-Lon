﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject bBullet =  Instantiate(gameObject, transform.position, transform.rotation);
            Rigidbody2D rigidBody = bBullet.GetComponent<Rigidbody2D>();
            rigidBody.velocity = bBullet.transform.right * 10;


            Destroy(bBullet, 10);
        }
    }
}
