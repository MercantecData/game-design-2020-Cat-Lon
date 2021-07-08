using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            AudioSource.PlayClipAtPoint(clip, Vector2.zero);
            GameObject bBullet =  Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rigidBody = bBullet.GetComponent<Rigidbody2D>();
            rigidBody.velocity = bBullet.transform.right * 10;

            Destroy(bBullet, 10);
        }
    }
}
