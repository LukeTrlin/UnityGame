using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


public class DoorDetector : MonoBehaviour
{
    public GameObject StaticPlayer;
    public GameObject player;
    private GameObject CurrentRoom;
    private string CurrentRoomID;
    public Camera Camera;
    public int Room = 1;

   

    public float[] ClearedRooms;
    List<int> IDs = new List<int>();

    public Respawn respawn; // Reference to the Respawn script

    void Start()
    {
        
        
        // You can add any additional logic here if needed
    }


    void Update()
    {

        
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for different door tags and the CanDoor condition
        if (collision.gameObject.CompareTag("TopDoor"))
        {
            HandleDoorTransition(new Vector3(0f, 20f, 0f));
            CurrentRoom = collision.gameObject.transform.parent.transform.parent.gameObject;
            CurrentRoomID = CurrentRoom.GetComponent<RoomIdentifier>().roomID;
            
            
            
            Debug.Log(CurrentRoom + CurrentRoomID);
            IDs.Add(Room);
            Room += 2;
            
            
            

        }

       

        else if (collision.gameObject.CompareTag("LeftDoor"))
        {
            HandleDoorTransition(new Vector3(-32.5f, 0f, 0f));
            CurrentRoom = collision.gameObject.transform.parent.transform.parent.gameObject;
            CurrentRoomID = CurrentRoom.GetComponent<RoomIdentifier>().roomID;
            
            
            
            Debug.Log(CurrentRoom + CurrentRoomID);
            IDs.Add(Room);
            Room -= 1;
            
            
        }
        else if (collision.gameObject.CompareTag("RightDoor"))
        {
            HandleDoorTransition(new Vector3(32.5f, 0f, 0f));
            CurrentRoom = collision.gameObject.transform.parent.transform.parent.gameObject;
            CurrentRoomID = CurrentRoom.GetComponent<RoomIdentifier>().roomID;
            
            
            Debug.Log(CurrentRoom + CurrentRoomID);
            IDs.Add(Room);
            Room += 1;
           
        }
        else if (collision.gameObject.CompareTag("BottomDoor"))
        {
            HandleDoorTransition(new Vector3(0f, -20f, 0f));
            CurrentRoom = collision.gameObject.transform.parent.transform.parent.gameObject;
            CurrentRoomID = CurrentRoom.GetComponent<RoomIdentifier>().roomID;
            
            
            
            Debug.Log(CurrentRoom + CurrentRoomID);
            IDs.Add(Room);
            Room -= 2;
            
            
        }
    }

    private void HandleDoorTransition(Vector3 movement)
    {
        if (respawn != null && respawn.CanDoor)
        {

            MoveDoorAndPlayer(movement);

            
            
                StartCoroutine(Waiter());
                

                IEnumerator Waiter()
                {
                    yield return new WaitForSeconds(3); // Wait before spawning the new skeleton
                     // Call the method to spawn a new skeleton
                     if (!IDs.Contains(Room))
                {
                    
                    
                    respawn.ReloadEnemies(5, 7); // Reload enemies after resetting

                }
                }

                
                
            
           
            
        }
    }

    private void MoveDoorAndPlayer(Vector3 movement)
    {
        // Move both the door and the static player by the specified movement vector
        gameObject.transform.position += movement;
        
        StaticPlayer.transform.position += movement;
    }

    private string GetCurrentRoomKey()
{
    RoomIdentifier identifier = GetComponent<RoomIdentifier>();
    return identifier != null ? identifier.roomID : gameObject.name; // Use the ID from the RoomIdentifier
}
}