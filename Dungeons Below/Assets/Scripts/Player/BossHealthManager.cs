using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthManager : MonoBehaviour
{

    public Image HealthBar; // Image Objects
    public float BossHealthAmount = 100f; // HealthAmount

    void Update()
    {
        
        if (BossHealthAmount <= 0) 
        {
            Destroy(gameObject);
        }

       
    }

    public void TakeDamage(float damage)
    {
        BossHealthAmount -= damage; // Subtracts Damage from health
        HealthBar.fillAmount = BossHealthAmount / 100; // Updates healthbar
    }




     void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Bullet") // Detects If the object collided with has the tag "Bullet
        {
            TakeDamage(2f); // Deals 20 Damage
        }
    }
}