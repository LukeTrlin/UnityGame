using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{  
  

    
    
    void start()
    {
        
    }

  
  


        

    void OnTriggerEnter2D(Collider2D collision)
    {
       
    

       
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
           
            Destroy(gameObject);
        }




    }





}
