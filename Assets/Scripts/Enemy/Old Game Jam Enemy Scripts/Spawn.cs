using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameManager gameManager; 
    public GameObject game;
    public int enemyCount; 

    //bool TempWave = true;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager");
        gameManager = game.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.spawnNewWave == true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(spawnPrefab, transform.position, transform.rotation);
            }
        }
        

    }
}
