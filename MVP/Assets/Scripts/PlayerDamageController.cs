using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public Image healthbar;
    Renderer rend;
    Color c;


    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = healthbar.GetComponent<HealthManager>();
        rend = GetComponent<Renderer> ();
        c = rend.material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") 
        {
                healthManager.TakeDamage(10);
                StartCoroutine ("Iframes");
        }   
    }
    
    IEnumerator Iframes ()
    {
        Physics2D.IgnoreLayerCollision (7, 8, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds (1f);
        Physics2D.IgnoreLayerCollision (7, 8, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
