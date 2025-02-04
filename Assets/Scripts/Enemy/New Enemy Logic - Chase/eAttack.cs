using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eAttack : MonoBehaviour
{
    [Header("DamangeStats")]
    public float attackDamage;
    public float attackCooldown;
    public pManagement pM;
    public eManager manager;
    [SerializeField] float attackCooldownMax;
    [SerializeField] float attackRange;

    [Header("Other")]
    [SerializeField] LayerMask attackable;
    [SerializeField] float chasingRange; 
    public pHealth playerHealth;
    public bool chase;
    public Transform chaseObject;
    public bool attackHold; 

    bool attacking;
    float attackTime; 
    [SerializeField] float attackTimeMax = 2f;

    [Header("audio")]
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioSource attackAudioSource; 

    GameObject theHitObject;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void FixedUpdate()
    {
        if (attackTime > 0)
        {
            attackHold = true;
            attackTime -= Time.deltaTime; 
        }
        else
        {
            attackHold=false;
        }
        pM = GameObject.Find("pController").GetComponent<pManagement>();
        if (attacking)
        {
            DamageLogic();
            pM.attacked = true;
            pM.damageTimer = 2f; 
            attackTime = attackTimeMax; 
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


        if (manager.parameter == 8)
        {
            attackAudioSource.PlayOneShot(attackClip);
        }
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

        if (Physics.Raycast(transform.position, fwd, out hit, chasingRange, attackable) )
        {
            chase = true;
            chaseObject = hit.transform; 
        } else
        {
            chase = false; 
        }
    }

}
