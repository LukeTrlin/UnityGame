using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMultiplier : MonoBehaviour
{
    [SerializeField] public static int floorsCleared;

    
    public int floorsCleareds = 0;
    public static bool KeepMultiplier = false;
    

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

    void Update()
    {

        floorsCleareds = floorsCleared;

    }


    void UpdateScore()
    {
        floorsCleared += 1;
        // HealthManager.floorMultiplier = 1 + (1 * floorsCleared);
        RoomFunctions.Keepscore = true;

    }
    

}
