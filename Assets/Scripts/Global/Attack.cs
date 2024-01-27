using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject enemy; 
    public string opponentTag; 
    public int damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == opponentTag)
        {
            enemy = other.gameObject;   
        }
    }

    public void Attacking ()
    {
        Health enemyHealth = enemy.gameObject.GetComponent<Health>();
        enemyHealth.health -= damageAmount;
        Debug.Log(enemyHealth.health);
    }
}
