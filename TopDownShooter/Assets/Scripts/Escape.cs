using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    public GameObject winText;
    public Text endText;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            winText.SetActive(true);
            AudioSource.PlayClipAtPoint(clip, Vector2.zero);
            Time.timeScale = 0;
        }
    }
}
