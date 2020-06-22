using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletHit : MonoBehaviour
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
        if (other.tag != "Enemy" && other.tag != "Walls" && other.tag != "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
