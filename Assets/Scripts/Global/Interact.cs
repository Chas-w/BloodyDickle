using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Attack Settings")]
    public bool damage;
    public float damageAmount;

    [Header("Raycast Settings")]
    public float castDist;

    [Header("Interaction Settings")]
    public Health enemyHealth;

    GameObject enemyHit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interaction();
        }
    }

    public void Interaction()
    {
        RaycastHit hit;

        //Attack
        if (Physics.Raycast(transform.position /*start position for ray*/ , transform.forward /*cast direction */ , out hit, castDist /* ray cast distance */))
        {
            if (hit.collider != null && hit.transform.tag == "Enemy")
            {
                enemyHit = hit.transform.gameObject;
                enemyHealth = enemyHit.GetComponent<Health>();
                damage = true;
            }
            else { damage = false; }

            if (damage)
            {

            }
        }
    }
}
