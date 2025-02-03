using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text healthDisplay;
    [SerializeField] TMP_Text wavesDisplay;

    public pHealth player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       healthDisplay.text = player.health.ToString() + " HP";
    }
}
