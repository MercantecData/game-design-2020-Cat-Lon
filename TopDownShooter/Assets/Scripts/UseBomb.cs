using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBomb : MonoBehaviour
{
    public GameObject bombObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bomb = Instantiate(bombObject,transform.position,transform.rotation);
        }
    }
}
