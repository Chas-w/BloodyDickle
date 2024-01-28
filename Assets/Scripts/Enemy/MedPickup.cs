using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPickup : MonoBehaviour
{
    public GameObject player;
    public Transform playerPos;
    public Health thisHealth;
    public int healthAddition; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("pController");
        thisHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform;
        Vector3 adjusted = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);
        transform.LookAt(adjusted);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (thisHealth.health <= thisHealth.healthMax) { thisHealth.health += healthAddition; }
            Destroy(gameObject, 1);
        }
    }
}
