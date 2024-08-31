using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Respawn : MonoBehaviour
{
    public TMP_Text text;
    public GameObject image;
    public GameObject Enemy;
    public int enemyCount = 5;
    private HealthManager healthManager;

    public Image HealthBar;
    public float HealthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = Enemy.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("Enemies Remaining:", enemyCount);
        


        if (enemyCount > 0)
        {
            if (healthManager.HealthAmount == 0)
            {
                StartCoroutine(waiter());
                Enemy.transform.position = new Vector3(1000,0,0);
                
            
                healthManager.HealthAmount += 100;
                HealthBar.fillAmount = HealthAmount / 100f;
                enemyCount -= 1;
                IEnumerator waiter()
                {
                    yield return new WaitForSeconds(1);
                    Enemy.transform.position = new Vector3(0,0,0);
                    
                    
                    
                }
                
                
                
            }
        }

        else {
            Enemy.SetActive(false);
            image.SetActive(true);
            
        }
        
        

    }
}
