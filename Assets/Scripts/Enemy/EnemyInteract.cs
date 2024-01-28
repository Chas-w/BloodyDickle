using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyInteract : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject player;
    public Health playerHealth;
    public string playerTag;
    public float damageAmount;

    [Header("Attack Cooldown")]
    public int damageTimerMax;
    public int damageTimer; 

    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) { playerHealth = player.gameObject.GetComponent<Health>(); }
        
        if (damageTimer >= 0)
        {
            damageTimer--;
        }
        if (damageTimer <= 0)
        {
            if (canAttack)
            {
                Attacking();
            }
            damageTimer = damageTimerMax;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            canAttack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {  
            canAttack = false;
        } 
    }

    void Attacking()
    {
        if (playerHealth.health >= 0) { playerHealth.health -= damageAmount; }
        Debug.Log(playerHealth.health);
    }
}
