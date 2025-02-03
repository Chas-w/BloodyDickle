using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public bool spawned;
    public int waves = 1; 
    public int spawnCount; 

    [SerializeField] Transform[] spawnLocation;
    [SerializeField] GameObject[] spawnTarget;


    float waveTime;
    float waveTimeMax = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        waveTime = waveTimeMax; 
    }

    // Update is called once per frame
    void Update()
    {
        var foundObjects = Object.FindObjectsOfType<eManager>();
        int count = foundObjects.Length;
        
        if (count <= 0)
        {
            waveTime -= Time.deltaTime; 
            if (waveTime < 0)
            {
                waves++;
                spawned = false;
                waveTime = waveTimeMax; 
            }
      
        }

        if (!spawned)
        {
            spawnCount = spawnLocation.Length;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnHere = spawnLocation[i].position;
                Instantiate(spawnTarget[i], spawnHere, transform.rotation);

            } 
            spawned = true;
        }   
    }
}
