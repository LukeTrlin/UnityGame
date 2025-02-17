using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



// Contains all functional aspects of a room = get room ID, is spawnable, etc

public class RoomFunctions : MonoBehaviour
{
    Color c;
    public AudioSource RoomCharm;
    private GameObject CurrentSkeletonEnemy;
    [SerializeField] public string RoomType; // Whether the player is in a basic, spawn, or boss room
    [SerializeField] public bool DoorsLocked = false; // Determines whether the doors are activated or not
    [SerializeField] string currentRoomId; // The ID of the current room

    public static int CurrentScore = 0;
    public int TotalEnemyCount;
    public int ActiveEnemies;
    public int MaxEnemyCount = 5;
    public int MinEnemyCount = 2;
    private PlayerDamageController playerDamageController;
    
    public TMP_Text highscore;

    public GameObject currentRoom;
    [SerializeField] List<string> ClearedRooms = new List<string>(); // List of cleared rooms

    // Enemy Spawning Variables
    public GameObject skeletonEnemy; // Skeleton gameobject
    public GameObject slimeBoss;// Slime gameobject
    public GameObject player; // player gameobject
    private GameObject CurrentRoom; // The room that the player is currently in
    private HealthManager SkeletonHealthManager; // Health manager for skeleton
    private HealthManager BossHealthManager; // Health manager for slime
    public GameObject FloorChanger;
    public GameObject ActiveFloorChanger;
    

    private GameObject ActiveSkeletonEnemy; // The active skeleton enemy
    private GameObject ActiveBoss; // The active skeleton enemy
    

    public RoomCounter roomCounter;
    public Image HealthBar; // HealthBar

    public bool spawnController = true;
    public Transform parent;

    public int BossAmount;
    public bool CanBossSpawn = true;
    public static bool BossDead = false;

    public DoorDetector doorDetector;
    public bool TouchDoor = false;
    private FloorChange floorChange;

    public static bool Keepscore = false;

    private int BossHealth;


    // Start is called before the first frame update
    void Start()
    {
        BossAmount = 1;
        StartCoroutine("Loading");
        if (Keepscore == false)
        {
            CurrentScore = 0;
            
           
        }

        playerDamageController = player.GetComponent<PlayerDamageController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        highscore.SetText("Current Score: " + CurrentScore);
    }


    void Update()
    {
        

        if (BossDead == true)
        {
            
            // instantiate floorchanger
            BossDead = false;
            
           
            StartCoroutine("AddFloorChangeItem");
            
        }

      if (SkeletonHealthManager != null && SkeletonHealthManager.HealthAmount <= 0)
        {
            SpawnSkeleton();
            ActiveEnemies -= 1;
        }


    }
        
        
    




    // Detecting what door the player interacts with
    void OnTriggerStay2D (Collider2D collision) { // Detects a collision every frame, rather than just detecting on entry


        // Detect if room is spawnable or not
        if (collision.gameObject.CompareTag("SpawnRoom"))
        {
            RoomType = "SpawnRoom";
            DoorsLocked = false;
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
            if (TouchDoor == false)
            {
                SceneManager.LoadScene(3);
                Debug.Log("Reset Room Due to Error");
            }
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            if (currentRoom.GetComponent<RoomCounter>().hasCleared == false)
            {
                if(spawnController == true)
            {
                DoorsLocked = true;
                SpawnSkeleton();  // If the room is not cleared, spawn an enemy
                spawnController = false;
            }
            }
            
            
            
          
        }

        else if (collision.gameObject.CompareTag("BossRoom"))
        {
            RoomType = "BossRoom";
            currentRoom = collision.gameObject;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            SpawnBoss();


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
            currentRoom = collision.gameObject.transform.parent.parent.gameObject;
            TouchDoor = true;
            gameObject.transform.position += new Vector3(0f, 20f, 0f);

            Keepscore = false;
        
            OnRoomLoad();
            Debug.Log("Door Detected");
        }

        else if (collision.gameObject.CompareTag("LeftDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            currentRoom = collision.gameObject.transform.parent.parent.gameObject;
            Keepscore = false;
            TouchDoor = true;
            gameObject.transform.position += new Vector3(-32.5f, 0f, 0f);
            OnRoomLoad();
            Debug.Log("Door Detected");
        }

        else if (collision.gameObject.CompareTag("RightDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            currentRoom = collision.gameObject.transform.parent.parent.gameObject;
            Keepscore = false;
            TouchDoor = true;
            gameObject.transform.position += new Vector3(32.5f, 0f, 0f);
            OnRoomLoad();
            Debug.Log("Door Detected");
        }

        else if (collision.gameObject.CompareTag("BottomDoor") && DoorsLocked == false) // If the door collision is detected and doors aren't locked, do the following 
        {
            currentRoom = collision.gameObject.transform.parent.parent.gameObject;
            Keepscore = false;
            TouchDoor = true;
            gameObject.transform.position += new Vector3(0f, -20f, 0f);
            OnRoomLoad();
            Debug.Log("Door Detected");
        }
    }

    public void OnRoomLoad() // Everything that should be done when the player enters a new room
    {
            TotalEnemyCount = Random.Range(MinEnemyCount, MaxEnemyCount);
            ActiveEnemies = TotalEnemyCount;
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
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
        if (ActiveEnemies > 0)
        {
            currentRoom.transform.Find("Doors").transform.Find("TopDoor").transform.Find("TopStatusIndicator").GetComponent<SpriteRenderer>().color = Color.red;
            currentRoom.transform.Find("Doors").transform.Find("BottomDoor").transform.Find("BottomStatusIndicator").GetComponent<SpriteRenderer>().color = Color.red;
            currentRoom.transform.Find("Doors").transform.Find("LeftDoor").transform.Find("LeftStatusIndicator").GetComponent<SpriteRenderer>().color = Color.red;
            currentRoom.transform.Find("Doors").transform.Find("RightDoor").transform.Find("RightStatusIndicator").GetComponent<SpriteRenderer>().color = Color.red;
            CurrentSkeletonEnemy = Instantiate(skeletonEnemy); // make this based on the current room position
            CurrentSkeletonEnemy.transform.position = new Vector3(currentRoom.transform.position.x + (Random.Range(7, -7)), currentRoom.transform.position.y + (Random.Range(3, -3)), currentRoom.transform.position.z);
            SkeletonHealthManager = CurrentSkeletonEnemy.GetComponent<HealthManager>();
            HealthBar = SkeletonHealthManager.HealthBar;
        }

        else if (ActiveEnemies == 0 && RoomType != "SpawnRoom")
        {
            DoorsLocked = false;
            Instantiate(RoomCharm);
            currentRoomId = currentRoom.GetComponent<RoomIdentifier>().roomID;
            ClearedRooms.Add(currentRoomId);
            currentRoom.GetComponent<RoomCounter>().hasCleared = true;
            currentRoom.transform.Find("Doors").transform.Find("TopDoor").transform.Find("TopStatusIndicator").GetComponent<SpriteRenderer>().color = Color.green;
            currentRoom.transform.Find("Doors").transform.Find("BottomDoor").transform.Find("BottomStatusIndicator").GetComponent<SpriteRenderer>().color = Color.green;
            currentRoom.transform.Find("Doors").transform.Find("LeftDoor").transform.Find("LeftStatusIndicator").GetComponent<SpriteRenderer>().color = Color.green;
            currentRoom.transform.Find("Doors").transform.Find("RightDoor").transform.Find("RightStatusIndicator").GetComponent<SpriteRenderer>().color = Color.green;
            CurrentScore += 1;
            playerDamageController.PlayerHealOnRoomClear();
            CurrentScore.ToString();
            
            spawnController = true;
        }
    }    

    public void SpawnBoss()
    {
        if (CanBossSpawn == true)
        {
        ActiveBoss = Instantiate(slimeBoss);
        CanBossSpawn = false;
        ActiveBoss.transform.position = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y - 3, 0);
        BossHealthManager = CurrentSkeletonEnemy.GetComponent<HealthManager>();
        HealthBar = BossHealthManager.HealthBar;
        }

        
    }

    public IEnumerator Loading()
    {
        Physics2D.IgnoreLayerCollision (7,0, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision (7, 0, false); // Allows collisions
    }

    public IEnumerator AddFloorChangeItem()
    {
        
        CurrentScore += 3;
        yield return new WaitForSeconds(3);
        ActiveFloorChanger = Instantiate(FloorChanger);
        ActiveFloorChanger.transform.position = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, -1);
    }

    public IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2);
    }
}
