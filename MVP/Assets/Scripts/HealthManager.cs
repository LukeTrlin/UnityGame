using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    // Fixes, Add Collision Detector to this script at bottom
    // Set The Detection Type To Bullet Tag and add this tag to bullet prefab
    // Set the Source Image for the health Bar, Image Type Filled
    // Horizontal, Left, 1





    public Image HealthBar;
    public float HealthAmount = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthAmount <= 0)
        {
            HealthBar.fillAmount = 80f;
            Debug.Log("Hit");
        
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        HealthBar.fillAmount = HealthAmount / 100;
    }




     void OnTriggerEnter2D(Collider2D collision)
    {
       
    

       
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Bullet")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
           
            TakeDamage(20f);
            Debug.Log("Bullet Hit Skeleton");
            
            

           
        }
    }
}
