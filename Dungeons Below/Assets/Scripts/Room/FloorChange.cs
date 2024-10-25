using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChange : MonoBehaviour
{
    private RoomFunctions roomFunctions;
    private BossHealthManager bossHealthManager;

    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            Debug.Log("Player Reached the end, reloading floors");
        }
    }
}
