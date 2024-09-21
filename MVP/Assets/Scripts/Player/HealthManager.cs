using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{

    public Image HealthBar; // Image Objects
    public float HealthAmount = 100f; // HealthAmount

    void Update()
    {
        if (HealthAmount <= 0) 
        {
            HealthBar.fillAmount = 80f; // Fills HealthBar to 80
        }

       
    }

    public void TakeDamage(float damage)
    {
        HealthAmount -= damage; // Subtracts Damage from health
        HealthBar.fillAmount = HealthAmount / 100; // Updates healthbar
    }




     void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Bullet") // Detects If the object collided with has the tag "Bullet
        {
            TakeDamage(20f); // Deals 20 Damage
        }
    }
}
