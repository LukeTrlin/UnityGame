using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Contains all functional aspects of a room = get room ID, is spawnable, etc

public class RoomFunctions : MonoBehaviour
{

    [SerializeField] public string RoomType; // Whether the player is in a basic, spawn, or boss room
    [SerializeField] public bool DoorsLocked = false; // Determines whether the doors are activated or not
    [SerializeField] string currentRoomId; // The ID of the current room

    public int TotalEnemyCount;
    public int ActiveEnemies;
    public int MaxEnemyCount = 5;
    public int MinEnemyCount = 2;

    
    

    public GameObject currentRoom;
    [SerializeField] List<string> ClearedRooms = new List<string>(); // List of cleared rooms

    // Enemy Spawning Variables
    public GameObject skeletonEnemy; // Skeleton gameobject

    public GameObject slimeEnemy;// Slime gameobject
    public GameObject player; // player gameobject
    public HealthManager SkeletonHealthManager; // Health manager for skeleton
    public HealthManager SlimeHealthManager; // Health manager for slime

    private GameObject ActiveSkeletonEnemy; // The active skeleton enemy
    private GameObject ActiveSlimeEnemy; // The active skeleton enemy
    

    public HealthManager healthManager; // Health Manager
    public Image HealthBar; // HealthBar
    public float HealthAmount = 100f; // Health Amount


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if (TotalEnemyCount > 0)
        {
            SpawnSkeleton();
            Debug.Log($"Total enemy count is equal to {TotalEnemyCount}");
        }

        if (healthManager.HealthAmount <= 0)
        {
            Debug.Log("Enemy died");
        }

        
    }

    // Detecting what door the player interacts with
    void OnTriggerStay2D (Collider2D collision) { // Detects a collision every frame, rather than just detecting on entry


        // Detect if room is spawnable or not
        if (collision.gameObject.CompareTag("SpawnRoom"))
        {
            RoomType = "SpawnRoom";
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            if (ClearedRooms.Contains(currentRoomId) == false && DoorsLocked == false) // Checks to see if the room ID is already in the list and if the doors are locked
            {
                ClearedRooms.Add(currentRoomId); // If the current roomID is not in the list and the doors are unlocked (AKA, the room is cleared), it is added
            }
        }

        else if (collision.gameObject.CompareTag("BasicRoom"))
        {
            RoomType = "BasicRoom";
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            if (ClearedRooms.Contains(currentRoomId) == false && DoorsLocked == false) // Checks to see if the room ID is already in the list and if the doors are locked
            {
                ClearedRooms.Add(currentRoomId); // If the current roomID is not in the list and the doors are unlocked (AKA, the room is cleared), it is added
            }
        }

        else if (collision.gameObject.CompareTag("BossRoom"))
        {
            RoomType = "BossRoom";
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            if (ClearedRooms.Contains(currentRoomId) == false && DoorsLocked == false) // Checks to see if the room ID is already in the list and if the doors are locked
            {
                ClearedRooms.Add(currentRoomId); // If the current roomID is not in the list and the doors are unlocked (AKA, the room is cleared), it is added
            }
        }        
    }

    void OnTriggerEnter2D (Collider2D collision) {

        // Doors transporting player to respective destinations
        if (collision.gameObject.CompareTag("TopDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            gameObject.transform.position += new Vector3(0f, 20f, 0f);
            OnRoomLoad();
        }

        else if (collision.gameObject.CompareTag("LeftDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            gameObject.transform.position += new Vector3(-32.5f, 0f, 0f);
            OnRoomLoad();
        }

        else if (collision.gameObject.CompareTag("RightDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            gameObject.transform.position += new Vector3(32.5f, 0f, 0f);
            OnRoomLoad();
        }

        else if (collision.gameObject.CompareTag("BottomDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            gameObject.transform.position += new Vector3(0f, -20f, 0f);
            OnRoomLoad();
        }
    }

    public void OnRoomLoad() // Everything that should be done when the player enters a new room
    {
        DoorsLocked = true;
        TotalEnemyCount = Random.Range(MinEnemyCount, MaxEnemyCount);
        ActiveEnemies = TotalEnemyCount;
    }


    private string GetCurrentRoomKey()
    {
    // Retrieves the unique key for the current room
    RoomIdentifier identifier = GetComponent<RoomIdentifier>();
    return identifier != null ? identifier.roomID : gameObject.name;
    }






    // SPAWNING ENEMY FUNCTIONS
    public void SpawnSkeleton()
    {
        if (TotalEnemyCount > 0 && ClearedRooms.Contains(currentRoomId) == false)
        {
        ActiveSkeletonEnemy = Instantiate(skeletonEnemy); // Creates the skeleton enemy in the scene
        SkeletonHealthManager = ActiveSkeletonEnemy.GetComponent<HealthManager>(); // Health manager
        ActiveSkeletonEnemy.transform.position = new Vector3(player.transform.position.x -5, player.transform.position.y, player.transform.position.z); // Determines where the enemy spawns
        HealthBar = SkeletonHealthManager.HealthBar;
        TotalEnemyCount -= 1;
        }
    }    

    public IEnumerator SpawnNewSkeleton()
    {
    SpawnSkeleton(); // Call the method to spawn a new skeleton
    yield return new WaitForSeconds(1); // Wait before spawning the new skeleton
    }


}
