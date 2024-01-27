using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamageManager : MonoBehaviour
{
    public int health;
    public int damage;
    // Start is called before the first frame update
    public void TakeDamage(int amount)
    {
        health -= amount; 
    }

    public void DealDamage(GameObject target) 
    {
        var hdm = target.GetComponent<HealthDamageManager>();
        if (hdm != null) { hdm.TakeDamage(damage); }
    }
}
