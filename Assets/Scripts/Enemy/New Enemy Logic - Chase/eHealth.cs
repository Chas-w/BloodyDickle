using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour
{
    public float health; 
    public float maxHealth;
    public eManager enemyManager;
    float eDiedTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            enemyManager.died = true; 
        }

        if (enemyManager.died)
        {
            eDiedTimer -= Time.deltaTime; 
            if (eDiedTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
