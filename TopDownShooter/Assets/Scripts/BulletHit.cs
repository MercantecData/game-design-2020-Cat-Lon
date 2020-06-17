using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
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
        if (other.tag != "Player" && other.tag != "Walls")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
