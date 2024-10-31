using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{

    public Image HealthBar; // Image Objects
    public static float EnemyMaxHealth = 100;
    public float HealthAmount; // HealthAmount
    [SerializeField] public float PrimaryBulletDamage;
    [SerializeField] public float SecondaryBulletDamage;

    public static float floorMultiplier = 1;

    public static float BaseDamage = 20;
    public static float SecondaryBaseDamage = 100;

    public float visualDamage;
    public float SecondaryvisualDamage;

    void Start ()
    {
        HealthAmount = EnemyMaxHealth;
    }
    

    void Update()
    {
        visualDamage = BaseDamage;
        SecondaryvisualDamage = SecondaryBaseDamage;
        if (HealthAmount <= 0) 
        {
            Destroy(gameObject);
        }

        PrimaryBulletDamage = BaseDamage;
        SecondaryBulletDamage = SecondaryBaseDamage;
        
       
    }

    public void TakeDamage(float damage)
    {
        HealthAmount -= damage; // Subtracts Damage from health
        HealthBar.fillAmount = HealthAmount / EnemyMaxHealth; // Updates healthbar
    }




     void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Bullet") // Detects If the object collided with has the tag "Bullet
        {
            
            
            TakeDamage(PrimaryBulletDamage); // Deals 20 Damage
        }

        if (collision.gameObject.tag == "SecondaryBullet")
        {
            TakeDamage(SecondaryBulletDamage);
        }
    }
}
