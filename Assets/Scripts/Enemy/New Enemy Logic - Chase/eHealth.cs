using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth : MonoBehaviour
{
    public float health; 
    public float maxHealth;
    public bool died; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
            died = true;

        if (died)
            Debug.Log("died");
    }
}
