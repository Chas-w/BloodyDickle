using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float health;
    public bool dead;
    public Animator anim;
    public GameObject gms;
    public GameManager gameManager;
    

    public bool enemy;
    [SerializeField] AudioSource enemyDeath;
     
    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        gms = GameObject.Find("GameManager");
        gameManager = gms.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            enemyDeath.Play();
            gameManager.finalWaveCount = gameManager.wave;
            dead = true;
        }

        
        if (enemy) 
        {
            if (dead)
            {
                Destroy(gameObject, 2);
                anim.SetTrigger("dead");

            }

        }
        else
        {
            if ((dead &&!enemy))
            {
                SceneManager.LoadScene("End");
            }
        }
        
    }
}
