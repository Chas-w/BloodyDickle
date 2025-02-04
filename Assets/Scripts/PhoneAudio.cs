using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneAudio : MonoBehaviour
{
    bool playedAudio;
    [SerializeField] AudioClip[] phoneClip;
    [SerializeField] AudioSource phoneSource;

    float countdown;
    float countdownMax; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown-= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (countdown <= 0)
            {
                phoneSource.PlayOneShot(phoneClip[Random.Range(0,phoneClip.Length)]);
                countdown = countdownMax;
            }
        }
    }
}
