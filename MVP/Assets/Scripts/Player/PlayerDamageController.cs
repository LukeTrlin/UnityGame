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

   
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") // If Collides with Enemies
        {
                healthManager.TakeDamage(10); // Player Takes Damage
                StartCoroutine ("Iframes"); // begins IFrames
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
}
