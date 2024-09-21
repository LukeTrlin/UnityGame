using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIdentifier : MonoBehaviour
{
    public string roomID; // Assign this in the Inspector or dynamically

    private void Awake()
    {
        // Generate a unique ID if none is assigned
        if (string.IsNullOrEmpty(roomID))
        {
            roomID = System.Guid.NewGuid().ToString(); // Generate a new unique ID
            Debug.Log($"Room ID assigned: {roomID}"); // For debugging
        }
    }
}