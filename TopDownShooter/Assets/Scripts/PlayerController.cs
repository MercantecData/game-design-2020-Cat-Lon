using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerBody;
    private Animator anim;
    private float currentHealth;
    public float maxHealth = 5f;
    public GameObject endText;
    public Text uiText;
    public Text healthUi;
    private float score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthUi.text = "Health: " + currentHealth + "/" + maxHealth;
        scoreText.text = "Score: " + score;
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

        if(currentHealth <= 0f)
        {
            string deathText = "You Died!";
            uiText.text = deathText;
            Destroy(gameObject);
            endText.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(amount < 0) 
        {
            anim.SetTrigger("Hurt");
        }
        healthUi.text = "Health: " + currentHealth + "/" + maxHealth;
    }
    public void ScoreChange(float amount)
    {
        score += amount;
        scoreText.text = "Score: " + score; 
    }
}
