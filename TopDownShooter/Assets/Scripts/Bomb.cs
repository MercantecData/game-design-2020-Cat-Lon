using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    float timer;
    BoxCollider2D boxCollider2D;
    bool canExplode;
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
    private void OnCollisionStay2D(Collider2D other)
    {
        if (canExplode)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
