using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public Image healthbar; // HealthBar Image
    Renderer rend; // Renderer
    Color c; // Color


    private HealthManager healthManager; // Finds health Manager
   
    void Start()
    {
        healthManager = healthbar.GetComponent<HealthManager>(); // Locates HealthManager
        rend = GetComponent<Renderer> (); // Defines Renderer
        c = rend.material.color; // Defines Colour
        
    }

    void Update()
    {
        if (healthManager.HealthAmount <= 0)
        {
            StartCoroutine("PlayerDied");
        }
    }
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") // If Collides with Enemies
        {
                healthManager.TakeDamage(10); // Player Takes Damage
                StartCoroutine ("Iframes"); // begins IFrames
        }   
        else if (collision.gameObject.tag == "BossEnemy")
        {
            healthManager.TakeDamage(20); // Boss deals more damage than a regular enemy
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

    IEnumerator PlayerDied()
    {
        Debug.Log("PlayerDied");
        healthManager.HealthAmount = 100;
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds (3);
    }
}
