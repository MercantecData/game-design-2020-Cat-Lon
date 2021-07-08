using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    public float range = 8f;
    public LayerMask mask;
    public GameObject player;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetAquired())
        {
                gameObject.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * speed;
        }
    }
    bool TargetAquired()
    {
        GameObject targetGo = GameObject.FindGameObjectWithTag("Player");
        bool inRange = false;
        bool inVision = false;
        if (Vector2.Distance(targetGo.transform.position, transform.position) < range)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy" && other.tag != "Walls" && other.tag != "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
