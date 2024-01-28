using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float health;
    public bool dead;

    public bool enemy; 
     
    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            dead = true;
        }

        if (enemy && dead)
        {
            Destroy(gameObject, 2); 
        }
    }
}
