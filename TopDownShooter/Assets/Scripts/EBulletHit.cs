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
        PlayerController player = other.GetComponent<PlayerController>();
        if (other.tag == "Player")
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
        else if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
