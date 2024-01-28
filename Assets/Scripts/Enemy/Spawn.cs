using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameManager gameManager;
    public int enemyCount; 

    //bool TempWave = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
