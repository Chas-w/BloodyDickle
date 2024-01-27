using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject enemy;
    public Health enemyHealth;
    public string opponentTag;
    public float damageAmount;
    

    bool canAttack; 


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null) { enemyHealth = enemy.gameObject.GetComponent<Health>(); }
        if (Input.GetMouseButton(0))
        {
            if (canAttack)
            {
                Attacking(); 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;
            canAttack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canAttack = false ;
        }
    }

    void Attacking()
    { 
        enemyHealth.health -= damageAmount;
        Debug.Log(enemyHealth.health);
    }
}
