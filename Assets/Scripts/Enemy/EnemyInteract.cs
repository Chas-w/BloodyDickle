using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyInteract : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject player;
    public Health playerHealth;
    public EnemyMovePattern enemyMovePattern;
    public string playerTag;
    public float damageAmount;

    [Header("Attack Cooldown")]
    public int damageTimerMax;
    public int damageTimer;
    public Animator anim; 

    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = 1.0f;
        if (player != null) { playerHealth = player.gameObject.GetComponent<Health>(); }
        enemyMovePattern.canMove = true;
        if (damageTimer >= 0)
        {
            damageTimer--;
            
        }
        if (damageTimer <= 0)
        {
            if (canAttack)
            {
                Attacking();
                anim.SetBool("attackAnim", true);

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
            anim.SetBool("canAttack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {  
            canAttack = false;
            anim.SetBool("attackAnim", false);
            anim.SetBool("canAttack", false);

        }
    }

    void Attacking()
    {
        if (playerHealth.health >= 0) { playerHealth.health -= damageAmount; }
        Debug.Log(playerHealth.health);
    }
}
