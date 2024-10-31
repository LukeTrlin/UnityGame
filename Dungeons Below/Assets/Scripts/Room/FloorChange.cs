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
        if (collision.gameObject.tag == "Player") // Floor difficulty scaling
        {
                BossHealthManager.BossMaxHealth = BossHealthManager.BossMaxHealth * 1.25f;
                HealthManager.EnemyMaxHealth = HealthManager.EnemyMaxHealth * 1.25f;
                PlayerDamageController.PlayerMaxHealth += 20;
                ManaManager.MaxManaAmount += 10;
                PlayerDamageController.SkeletonDamage = PlayerDamageController.SkeletonDamage * 1.25f;
                PlayerDamageController.SlimeDamage = PlayerDamageController.SlimeDamage * 1.25f;
                
                FloorMultiplier.floorsCleared += 1;
                FloorMultiplier.KeepMultiplier = true;
                HealthManager.floorMultiplier = 1 + (1 * floorsCleared);
                RoomFunctions.Keepscore = true;
                SceneManager.LoadScene(3);
                Debug.Log("Player Reached the end, reloading floors");
        }
    }
}
