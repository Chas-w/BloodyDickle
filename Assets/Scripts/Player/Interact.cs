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
    public bool damaging; 

    public bool canAttack; 


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null) { enemyHealth = enemy.gameObject.GetComponent<Health>(); }
        damaging = false;

        if (Input.GetMouseButton(0))
        {
            if (canAttack)
            {
                damaging = true; 
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

    public void Attacking()
    {
        if (enemyHealth.health >= 0) { enemyHealth.health -= damageAmount; }
        Debug.Log(enemyHealth.health);
    }
}
