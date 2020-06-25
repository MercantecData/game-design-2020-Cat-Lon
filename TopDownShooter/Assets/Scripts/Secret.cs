using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secret : MonoBehaviour
{
    public GameObject player;
    public GameObject userInterface;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Submit") > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(userInterface);
            SceneManager.LoadScene(1);
        }
    }
}
