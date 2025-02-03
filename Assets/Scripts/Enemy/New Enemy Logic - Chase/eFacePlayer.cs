using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFacePlayer : MonoBehaviour
{
   

    [Header("Player Data")]
    public Transform playerPos;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.Find("pController"); 
        FacePlayer(); 

    }

    private void FacePlayer()
    {
        playerPos = player.transform;
        Vector3 adjusted = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);
        transform.LookAt(adjusted);
    }
}
