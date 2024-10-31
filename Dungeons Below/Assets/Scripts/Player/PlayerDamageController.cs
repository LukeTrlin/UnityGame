using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public Image PlayerHealthBar; // HealthBar Image
    public float PlayerHealthAmount;
    public TMP_Text ShowHealthNumbers;
    public static float PlayerMaxHealth = 100;
    public static float SkeletonDamage = 10;
    public static float SlimeDamage = 20;
    Renderer rend; // Renderer
    Color c; // Color
   
    void Start()
    {
        rend = GetComponent<Renderer> (); // Defines Renderer
        c = rend.material.color; // Defines Colour
        PlayerHealthAmount = PlayerMaxHealth;
        Physics2D.IgnoreLayerCollision (7, 8, false);
    }

    void Update()
    {
        if (PlayerHealthAmount <= 0)
        {
            PlayerDied();
        }
        ShowHealthNumbers.text = $"{PlayerHealthAmount} / {PlayerMaxHealth}";
    }

    public void PlayerTakeDamage(float damage)
    {
        PlayerHealthAmount -= damage; // Subtracts Damage from health
        PlayerHealthBar.fillAmount = PlayerHealthAmount / PlayerMaxHealth; // Updates healthbar
    }

    
    public void PlayerHeal(float heal)
    {
        PlayerHealthAmount += heal; // Adds heal to health
        PlayerHealthBar.fillAmount = PlayerHealthAmount / PlayerMaxHealth;
        if (PlayerHealthAmount > PlayerMaxHealth)
        {
            PlayerHealthAmount = PlayerMaxHealth;
        }
    }
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") // If Collides with Enemies
        {
                PlayerTakeDamage(SkeletonDamage); // Player Takes Damage
                StartCoroutine ("Iframes"); // begins IFrames
        }   
        else if (collision.gameObject.tag == "BossEnemy")
        {
            PlayerTakeDamage(SlimeDamage); // Boss deals more damage than a regular enemy
            StartCoroutine ("Iframes"); // Begins Iframes coroutine
        }
    }
    
    IEnumerator Iframes () // IFrames timer
    {
        Physics2D.IgnoreLayerCollision (7, 8, true); // Ignores Collision with enemies
        c.a = 0.5f; // Changes Transparency
        rend.material.color = c; // Changes Colour
        yield return new WaitForSeconds (1f); // Waits for Iframes to end
        Physics2D.IgnoreLayerCollision (7, 8, false); // Allows collisions
        c.a = 1f; // transparency back to normal
        rend.material.color = c; // resets colour
    }

    void PlayerDied()
    {
        Debug.Log("PlayerDied");
        PlayerHealthAmount = 100;
        SceneManager.LoadScene(2);
    }

    public void PlayerHealOnRoomClear()
    {
        PlayerHeal(10);
    }
}