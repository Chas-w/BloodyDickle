using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pAttack : MonoBehaviour
{
    [Header("DamangeStats")]
    public float attackDamage;
    float attackCooldown;
    [SerializeField] float attackCooldownMax;
    [SerializeField] float attackRange;

    [Header("Animation")]
    public Animator handsAnim;


    [Header("Other")]
    [SerializeField] LayerMask attackable;
    public eHealth enemyAttacked;
    public eManager enemy; 
    bool attacking;

    GameObject theHitObject; 

    // Start is called before the first frame update
    void Start()
    {
        //handAnimator = hands.GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
        if (attacking)
        {
            DamageLogic();
            enemy.attacked = true; 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        TriggerAttack();
        handsAnim.speed = 0;
        if (Input.GetMouseButton(0))
        {
            handsAnim.speed = 1;
        }


    }

    private void DamageLogic()
    {
        enemyAttacked = theHitObject.GetComponent<eHealth>();
        enemyAttacked.health -= attackDamage * Time.deltaTime;
    }

    private void TriggerAttack()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, attackRange, attackable))
        {
            theHitObject = hit.collider.gameObject;
            enemy = theHitObject.GetComponent<eManager>(); 
            if (Input.GetMouseButton(0))
            {
                attacking = true;
            }
            if (!Input.GetMouseButton(0))
            {
                attacking = false;
                enemy.attacked = false;

            }
        }
        else
        {
            attacking = false;
            enemy.attacked = false; 
        }
    }
}

