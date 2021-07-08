﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ScoreChange(200);
            Destroy(gameObject);
        }
    }
}
