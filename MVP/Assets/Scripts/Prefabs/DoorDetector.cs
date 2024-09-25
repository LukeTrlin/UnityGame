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

    
    List<int> IDs = new List<int>();
    

    [SerializeField]List<string> ClearedRooms = new List<string>();

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


        if (collision.gameObject.CompareTag("Debug"))
        {
            Debug.Log("Found Room");
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            


        }
      
        // Check for different door tags and the CanDoor condition
        if (collision.gameObject.CompareTag("TopDoor"))
        {
            StartCoroutine("cantDoor");
            HandleDoorTransition(new Vector3(0f, 20f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(ClearedRoomID);
            
            
           
           
            
            
            

        }

       

        else if (collision.gameObject.CompareTag("LeftDoor"))
        {
            StartCoroutine("cantDoor");
            HandleDoorTransition(new Vector3(-32.5f, 0f, 0f));
           Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            
            
            
            
            
            
        }
        else if (collision.gameObject.CompareTag("RightDoor"))
        {
            StartCoroutine("cantDoor");
            HandleDoorTransition(new Vector3(32.5f, 0f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
           
            
           
           
        }
        else if (collision.gameObject.CompareTag("BottomDoor"))
        {
            StartCoroutine("cantDoor");
            
            HandleDoorTransition(new Vector3(0f, -20f, 0f));
            Clearedroom = collision.gameObject.transform.parent.transform.parent.gameObject;
            ClearedRoomID = Clearedroom.GetComponent<RoomIdentifier>().roomID;
            
            
           
            
            
            
            
        }
    }

    private void HandleDoorTransition(Vector3 movement)
    {
        if (respawn != null && respawn.CanDoor)
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