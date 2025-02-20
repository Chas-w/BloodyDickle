using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public pHealth playerHealth;
    public pManagement playerManagement;
    public bool spawnNewWave;
    public int wave;
    public static GameManager Instance { get; private set; }

    float youDiedTimer = 3f; 

    public int finalWaveCount; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = FindObjectOfType<pHealth>();
        var enemyNum = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyNum.Length == 0)
        {
            spawnNewWave = true;
            wave++;
            playerHealth.health += 1f;
        } else if (enemyNum.Length >= 0) { spawnNewWave = false;  }
        if (SceneManager.GetActiveScene().name == "Rebrand")
        {
            player = GameObject.Find("pController");
            playerManagement = player.gameObject.GetComponent<pManagement>();

            if (playerManagement.died == true) 
            {
                youDiedTimer -= Time.deltaTime; 
                if (youDiedTimer < 0)
                {
                    SceneManager.LoadScene("End");
                }
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None; 
                SceneManager.LoadScene("Main Menu");
            }
        }
        

    }
}
