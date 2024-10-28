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
    Renderer rend; // Renderer
    Color c; // Color
   
    void Start()
    {
        rend = GetComponent<Renderer> (); // Defines Renderer
        c = rend.material.color; // Defines Colour
        PlayerHealthAmount = 100;
        Physics2D.IgnoreLayerCollision (7, 8, false);
    }

    void Update()
    {
        if (PlayerHealthAmount <= 0)
        {
            PlayerDied();
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        PlayerHealthAmount -= damage; // Subtracts Damage from health
        PlayerHealthBar.fillAmount = PlayerHealthAmount / 100; // Updates healthbar
    }
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") // If Collides with Enemies
        {
                Debug.Log("Collision Detected. Player takes damage");
                PlayerTakeDamage(10); // Player Takes Damage
                StartCoroutine ("Iframes"); // begins IFrames
        }   
        else if (collision.gameObject.tag == "BossEnemy")
        {
            PlayerTakeDamage(20); // Boss deals more damage than a regular enemy
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
}
