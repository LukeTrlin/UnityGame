using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthManager : MonoBehaviour
{

    public Image PlayerHealthBar; // Image Objects
    public float PlayerHealthAmount = 101f; // HealthAmount

    void Update()
    {
        if (PlayerHealthAmount <= 1) 
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        PlayerHealthAmount -= damage; // Subtracts Damage from health
        PlayerHealthBar.fillAmount = PlayerHealthAmount / 100; // Updates healthbar
    }
}
