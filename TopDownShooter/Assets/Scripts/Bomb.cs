using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    float timer;
    BoxCollider2D boxCollider2D;
    bool canExplode;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        boxCollider2D = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            canExplode = true;
        }
        print(timer);
       
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (canExplode)
        {
            if(other.tag == "Walls")
            {
                print("connects with wall at all: this should always happen");
                Tilemap tilemap = GetComponent<Tilemap>();
                print("hit wall");
                Vector2 hit = other.transform.position;
                print("position of wall: " + hit);
                tilemap.SetTile(tilemap.WorldToCell(hit), null);
                print("wall should equal null");
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
