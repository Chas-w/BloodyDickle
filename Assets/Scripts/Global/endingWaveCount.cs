using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endingWaveCount : MonoBehaviour
{
    public GameObject gms;
    public GameManager gameManager;
    public GameObject health;
    public Health playerH; 
    public TMP_Text waveCnt;
    public TMP_Text healthtxt; 



    // Start is called before the first frame update
     void Awake()
    {
        gms = GameObject.Find("GameManager");
        gameManager = gms.GetComponent<GameManager>();
        health = GameObject.Find("pController");
        playerH = health.GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        
        waveCnt.text = gameManager.finalWaveCount.ToString();
        healthtxt.text = playerH.health.ToString() + " HP";

    }
}
