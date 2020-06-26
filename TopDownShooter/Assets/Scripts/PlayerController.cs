using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject endText;
    
    private Rigidbody2D playerBody;
    private Animator anim;
    
    public int maxHealth = 5;
    public float speed;
    public int currentHealth;

    public Text uiText;
    public Text healthUi;
    public Text scoreText;
    
    public AudioClip clip;
    public float playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        
        playerScore = PlayerManager.Instance.storedScore;
        currentHealth = PlayerManager.Instance.storedHealth;
        healthUi.text = "Health: " + currentHealth + "/" + maxHealth;
        scoreText.text = "Score: " + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * Input.GetAxis("Horizontal");
        position.y += speed * Time.deltaTime * Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        playerBody.MovePosition(position);

    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(amount < 0) 
        {
            anim.SetTrigger("Hurt");
        }
        healthUi.text = "Health: " + currentHealth + "/" + maxHealth;
        if (currentHealth <= 0f)
        {
            string deathText = "You Died!";
            uiText.text = deathText;
            endText.SetActive(true);
            AudioSource.PlayClipAtPoint(clip, Vector2.zero);
            Destroy(gameObject);
        }
    }
    public void ScoreChange(float amount)
    {
        playerScore += amount;
        scoreText.text = "Score: " + playerScore; 
    }
}
