using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthManager : MonoBehaviour
{

    public Image HealthBar; // Image Objects
    public float BossHealthAmount = 100f; // HealthAmount
    
    
    public GameObject Player;
    [SerializeField] public float PrimaryBulletDamageBoss;
    [SerializeField] public float SecondaryBulletDamageBoss;

    public static float BaseDamageBoss = 2;
    public static float SecondaryBaseDamageBoss = 8;

    void Start()
    {

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
        HealthBar.fillAmount = BossHealthAmount / 100; // Updates healthbar
    }




     void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Bullet") // Detects If the object collided with has the tag "Bullet
        {
            TakeDamage(PrimaryBulletDamageBoss); // Deals 20 Damage
        }

        if (collision.gameObject.tag == "SecondaryBullet")
        {
            TakeDamage(SecondaryBulletDamageBoss);
        }
    }
}