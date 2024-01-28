using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Health playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Mia Scene")
        {
            if (playerHealth.dead == true) { SceneManager.LoadScene("Lose"); }
        }
        if (SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Menu") {/*move to game scene*/ }
    }
}
