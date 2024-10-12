using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


public class DoorDetector : MonoBehaviour
{
    [SerializeField] string currentRoomId;
    public GameObject StaticPlayer;
    public GameObject player;
   
    private string ClearedRoomID;
    public Camera Camera;
    public int Room = 50;

    public GameObject currentRoom;

    public GameObject Clearedroom;

    private bool testBool;

    List<int> IDs = new List<int>();
    

    [SerializeField]List<string> ClearedRooms = new List<string>();

    public Respawn respawn; // Reference to the Respawn script
    [SerializeField] public bool DoorsOpen;

    void Start()
    {
        DoorsOpen = true;
        testBool = true;
        
        // You can add any additional logic here if needed
    }


    void Update()
    {

        
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Debug"))
        {
            Debug.Log("Found Room");
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            


        }
      
        // Check for different door tags and the CanDoor condition

        // Top door moving player to the room above
        if (collision.gameObject.CompareTag("TopDoor") && DoorsOpen == true)
        {
            HandleDoorTransition(new Vector3(0f, 20f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(ClearedRoomID);
        }

        // Left door moving player to the room to the left
        else if (collision.gameObject.CompareTag("LeftDoor") && DoorsOpen == true)
        {
            HandleDoorTransition(new Vector3(-32.5f, 0f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(ClearedRoomID);
        }
        // Right door moving player to the room to the right
        else if (collision.gameObject.CompareTag("RightDoor") && DoorsOpen == true)
        {
            HandleDoorTransition(new Vector3(32.5f, 0f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(ClearedRoomID);
        }
        // Bottom door moving player to the room below
        else if (collision.gameObject.CompareTag("BottomDoor") && DoorsOpen == true)
        {
            HandleDoorTransition(new Vector3(0f, -20f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(ClearedRoomID);
        }
    }

    private void HandleDoorTransition(Vector3 movement)
    {
        if (testBool = true)
        {
            ClearedRooms.Add(currentRoomId);
            MoveDoorAndPlayer(movement);
            
            
            
                StartCoroutine(Waiter());
                

                IEnumerator Waiter()
                {
                    yield return new WaitForSeconds(0.5f); // Wait before spawning the new skeleton
                     // Call the method to spawn a new skeleton
                    if (!ClearedRooms.Contains(currentRoomId))
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