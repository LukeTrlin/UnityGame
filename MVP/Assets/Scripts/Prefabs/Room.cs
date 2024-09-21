using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    // Defines Doors
    [SerializeField] GameObject topDoor;
    [SerializeField] GameObject bottomDoor;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;

    public Vector2Int RoomIndex {get; set; }

    public void OpenDoor(Vector2Int direction) {
        if (direction == Vector2Int.up) { // If Room Above set true
            topDoor.SetActive(true);
        }

        if (direction == Vector2Int.down) { // If Room Below Set True
        bottomDoor.SetActive(true);
        }

        if (direction == Vector2Int.left) { // IF Room left set true
        leftDoor.SetActive(true);
        }

        if (direction == Vector2Int.right) { // IF room Right set true
        rightDoor.SetActive(true);
        }
    }
}
