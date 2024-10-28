using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    private RoomFunctions roomFunctions;
    [SerializeField] public static int floorsCleared;

    private static bool KeepMultiplier = false;
    

    void Start()
    {

        if (KeepMultiplier == false)
        {
            floorsCleared = 0;
        }

        else
        {
            KeepMultiplier = false;
        }


    }

    // Start is called before the first frame update
    void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                HealthManager.BaseDamage = HealthManager.BaseDamage * 0.75f;
                HealthManager.SecondaryBaseDamage = HealthManager.SecondaryBaseDamage * 0.75f;
                
                BossHealthManager.BaseDamageBoss = BossHealthManager.BaseDamageBoss * 0.75f;
               BossHealthManager.SecondaryBaseDamageBoss = BossHealthManager.SecondaryBaseDamageBoss * 0.75f;
                
                FloorMultiplier.floorsCleared += 1;
                FloorMultiplier.KeepMultiplier = true;
                HealthManager.floorMultiplier = 1 + (1 * floorsCleared);
                RoomFunctions.Keepscore = true;
                SceneManager.LoadScene(3);
                Debug.Log("Player Reached the end, reloading floors");



            
            
        }
    }
}
