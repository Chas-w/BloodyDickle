using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eAttack : MonoBehaviour
{
    [Header("DamangeStats")]
    public float attackDamage;
    public float attackCooldown;
    [SerializeField] float attackCooldownMax;
    [SerializeField] float attackRange;

    [Header("Other")]
    [SerializeField] LayerMask attackable;
    public pHealth playerHealth;
    bool attacking;

    GameObject theHitObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (attacking)
        {
            DamageLogic();
            Debug.Log("attack");
        }

        if (attackCooldown <= attackCooldownMax)
        {
            attackCooldown += Time.deltaTime;
            attacking = false; 
        }
        if (attackCooldown >= attackCooldownMax)
        {
            attackCooldown = attackCooldownMax;
        }
        TriggerAttack();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DamageLogic()
    {
        playerHealth = theHitObject.GetComponent<pHealth>();
        playerHealth.health -= attackDamage;
    }

    private void TriggerAttack()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, attackRange, attackable))
        {
            theHitObject = hit.collider.gameObject;
            if (attackCooldown == attackCooldownMax)
            {
                attacking = true;
                attackCooldown = 0;
            } 
        }
        else 
        {
            attacking = false;
        }
    }

}
