using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public pManagement pM; 
  // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            pM.died = true;
        }
    }
}
