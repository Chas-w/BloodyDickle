using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Health playerHealth;
    public bool spawnNewWave;
    public int waveCount; 
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
        } else if (enemyNum.Length >= 0) { spawnNewWave = false;  }
        //if (SceneManager.GetActiveScene().name == "Mia Scene")
        //{
        //   if (playerHealth.dead == true) { SceneManager.LoadScene("Lose"); }
        // }
        //if (SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Menu") {/*move to game scene*/ }
    }
}
