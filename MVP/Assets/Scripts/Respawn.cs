using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int enemyCount = 5;
    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.HealthAmount <= 0)
        {
            Debug.Log("Enemy Ded");
        }

    }
}
