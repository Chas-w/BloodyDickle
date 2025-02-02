using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackGeneral : MonoBehaviour
{
    [Header("DamangeStats")]
    public Health characterAttacked;
    public float attackDamage;
    float attackCooldown;
    [SerializeField] float attackCooldownMax;
    [SerializeField] float attackRange; 

    [Header("Other")]
    [SerializeField] LayerMask attackable; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if ((Physics.Raycast(transform.position, fwd, attackRange, attackable)) && Input.GetMouseButtonDown(0))
        {
            print("enemy");
        }
            
    }
}
