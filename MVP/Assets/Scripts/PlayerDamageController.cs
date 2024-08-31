using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public Image healthbar;


    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = healthbar.GetComponent<HealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.HealthAmount == 0)
        {
            SceneManager.LoadScene("BasicScene");
        }
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(waiter());
       
        IEnumerator waiter()
        {
           if (collision.gameObject.transform.GetChild(0).gameObject.tag == "Enemy")
        {
            while (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton")
            {
                healthManager.TakeDamage(10);
                yield return new WaitForSeconds(1);
            }
           
            
        } 
        }

       
        
        




    }
}
