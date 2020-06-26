using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController player;
    public float storedScore;
    public int storedHealth;
    public static PlayerManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player.currentHealth = Instance.storedHealth;
        player.playerScore = Instance.storedScore;
    }

    // Update is called once per frame
    void Update()
    {
        SaveData();
    }
    public void SaveData()
    {
        PlayerManager.Instance.storedHealth = player.currentHealth;
        PlayerManager.Instance.storedScore = player.playerScore;
    }
}
