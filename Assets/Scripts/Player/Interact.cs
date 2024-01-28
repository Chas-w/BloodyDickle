using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject enemy;
    public Health enemyHealth;
    public Animator handsAnim;
    public string opponentTag;
    public float damageAmount;
    public bool damaging; 

    public bool canAttack;

    [SerializeField] AudioSource tickeSFX;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null) { enemyHealth = enemy.gameObject.GetComponent<Health>(); }
        damaging = false;
        handsAnim.speed = 0; 
        if (Input.GetMouseButton(0))
        {
            handsAnim.speed = 1;
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
        //play tickle audio
        tickeSFX.Play();
        if (enemyHealth.health >= 0) { enemyHealth.health -= damageAmount; }
        Debug.Log(enemyHealth.health);
    }
}
