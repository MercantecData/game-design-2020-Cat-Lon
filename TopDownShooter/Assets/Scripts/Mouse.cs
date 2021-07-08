using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        var mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

        var timToMousePosition = mousePosWorld - transform.position;
        timToMousePosition.z = 0;

        transform.right = timToMousePosition; //ud fra "tim" mod musen
    }
}
