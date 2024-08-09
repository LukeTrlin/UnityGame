using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
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
        if (enemyCount > 0)
        {
            if (healthManager.HealthAmount == 0)
            {
                healthManager.HealthAmount += 100;
                HealthBar.fillAmount = HealthAmount / 100f;
                enemyCount -= 1;
                Enemy.transform.position = new Vector3(0,0,0);
                
            }
        }

        else {
            Enemy.SetActive(false);
        }
        
        

    }
}
