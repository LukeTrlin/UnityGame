using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthManager : MonoBehaviour
{

    public Image HealthBar; // Image Objects
    public static float BossMaxHealth = 1000;
    public float BossHealthAmount; // HealthAmount
    
    
    public GameObject Player;
    [SerializeField] public float PrimaryBulletDamageBoss;
    [SerializeField] public float SecondaryBulletDamageBoss;

    public static float BaseDamageBoss = 20;
    public static float SecondaryBaseDamageBoss = 80;

    void Start()
    {
        BossHealthAmount = BossMaxHealth;
        PrimaryBulletDamageBoss = BaseDamageBoss;
        SecondaryBulletDamageBoss = SecondaryBaseDamageBoss;


    }
    void Update()
    {
        
        if (BossHealthAmount <= 1) 
        {
            RoomFunctions.BossDead = true;
            Debug.Log("Boss Died");
            Destroy(gameObject);
            
        }

       
    }

    public void TakeDamage(float damage)
    {
        BossHealthAmount -= damage; // Subtracts Damage from health
        HealthBar.fillAmount = BossHealthAmount / BossMaxHealth; // Updates healthbar
    }




     void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Bullet") // Detects If the object collided with has the tag "Bullet
        {
            TakeDamage(PrimaryBulletDamageBoss);
        }

        if (collision.gameObject.tag == "SecondaryBullet")
        {
            TakeDamage(SecondaryBulletDamageBoss);
        }
    }
}