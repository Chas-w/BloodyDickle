using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Health playerHealth;
    public bool spawnNewWave;
    public int wave;
    public static GameManager Instance { get; private set; }

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
        var enemyNum = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyNum.Length == 0)
        {
            spawnNewWave = true;
            wave++; 
        } else if (enemyNum.Length >= 0) { spawnNewWave = false;  }
        if (SceneManager.GetActiveScene().name == "Mia Scene")
        {
           if (playerHealth.dead == true) { SceneManager.LoadScene("Win"); }
         }
        if (SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Menu") { if (Input.GetMouseButtonDown(0)) { SceneManager.LoadScene("Mia Scene"); } }
    }
}
