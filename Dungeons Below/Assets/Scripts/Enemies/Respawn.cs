using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Respawn : MonoBehaviour
{
    public Dictionary<string, bool> roomStates = new Dictionary<string, bool>(); // Dictionary to track room states
    public GameObject skeletonEnemy;
    public GameObject player;
    public HealthManager SkeletonHealthManager;
    public HealthManager SlimeHealthManager;
    public GameObject slimeEnemy;

    public int MaxEnemyCount = 5; // Max Enemies
    public int MinEnemyCount = 3;

    private GameObject CurrentSkeletonEnemy;
    private GameObject CurrentSlimeEnemy;
    public int enemyCount;
    public int SkeletonsSpawnable;
    public int SlimeSpawnable;
    public int SkeletonsSpawned = 1; // Adjusted to 1 for initial spawn
    public int SlimesSpawned = 1;

    private HealthManager healthManager; // Health Manager
    public Image HealthBar; // HealthBar
    public float HealthAmount = 100f; // Health Amount
    public int RoomType;

    public DoorDetector doorDetector;

    void Start()
    {
        enemyCount = Random.Range(MinEnemyCount, MaxEnemyCount);
        SkeletonsSpawnable = Random.Range(1, enemyCount); // Ensure at least one skeleton can spawn
        SlimeSpawnable = enemyCount - SkeletonsSpawnable;


        

        Debug.Log("Enemies Total: " + enemyCount);
        Debug.Log("Skeletons Spawnable: " + SkeletonsSpawnable);
        Debug.Log("Slimes Spawnable: " + SlimeSpawnable);

        healthManager = new HealthManager();

        if (SkeletonsSpawnable > 0 && RoomType == 1)
        {
            SpawnSkeleton();
        }

        if (SlimeSpawnable > 0 && RoomType == 1)
        {
            SpawnSlime();
        }

        if (RoomType == 1)
        {
        Debug.Log("Roomtype is detected as entry room");
        }

        if (RoomType == 2)
        {
        Debug.Log("Roomtype is detected as basic room");
        }

        if (RoomType == 3)
        {
        Debug.Log("Roomtype is detected as boss room");
        }
    }

    void Update()
    {
        if (SkeletonsSpawned >= SkeletonsSpawnable && SlimesSpawned >= SlimeSpawnable)
        {
            doorDetector.DoorsOpen = true;
        }

        if (SkeletonsSpawned < SkeletonsSpawnable || SlimesSpawned < SlimeSpawnable)
        {
            doorDetector.DoorsOpen = false;
        }



        if (SkeletonHealthManager != null && SkeletonHealthManager.HealthAmount <= 0)
        {
            Destroy(CurrentSkeletonEnemy);
            SkeletonsSpawned++;

            // Only spawn if we haven't reached the maximum number of spawned skeletons
            if (SkeletonsSpawned < SkeletonsSpawnable)
            {
                StartCoroutine(SpawnNewSkeleton());
            }
        }


        if (SlimeHealthManager != null && SlimeHealthManager.HealthAmount <= 0)
        {
            Destroy(CurrentSlimeEnemy);
            SlimesSpawned++;

            // Only spawn if we haven't reached the maximum number of spawned skeletons
            if (SlimesSpawned < SlimeSpawnable)
            {
                StartCoroutine(SpawnNewSlime());
            }
        }
    }

    IEnumerator SpawnNewSkeleton()
    {
        yield return new WaitForSeconds(1); // Wait before spawning the new skeleton
        SpawnSkeleton(); // Call the method to spawn a new skeleton
    }

    IEnumerator SpawnNewSlime()
    {
        yield return new WaitForSeconds(3); // Wait before spawning the new slime
        SpawnSlime(); // Call the method to spawn a new slime
    }

    public void SpawnSkeleton()
    {
        CurrentSkeletonEnemy = Instantiate(skeletonEnemy);
        CurrentSkeletonEnemy.transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z);
        SkeletonHealthManager = CurrentSkeletonEnemy.GetComponent<HealthManager>();
        HealthBar = SkeletonHealthManager.HealthBar;
    }

    public void SpawnSlime()
    {
        CurrentSlimeEnemy = Instantiate(slimeEnemy);
        CurrentSlimeEnemy.transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z);
        SlimeHealthManager = CurrentSlimeEnemy.GetComponent<HealthManager>();
        HealthBar = SlimeHealthManager.HealthBar;
    }

  
  
        public void ReloadEnemies(int min, int max)
        {
            string currentRoomKey = GetCurrentRoomKey();
            Debug.Log($"Checking room state for {currentRoomKey}");
            
            if (roomStates.TryGetValue(currentRoomKey, out bool isCleared) && isCleared)
            {
                Debug.Log("Room is already cleared. No enemies will spawn.");
                return;
            }



            enemyCount = Random.Range(min, max);
            SkeletonsSpawnable = Random.Range(1, enemyCount); // Ensure at least one skeleton can spawn
            SlimeSpawnable = enemyCount - SkeletonsSpawnable;
            SlimesSpawned = 0;
            SkeletonsSpawned = 0;
            if (SkeletonsSpawnable > 0)
            {
                SpawnSkeleton();
            }

            if (SlimeSpawnable > 0)
            {
                SpawnSlime();
            }
            

        }

       private string GetCurrentRoomKey()
    {
        // Generate a unique key for the current room
        RoomIdentifier identifier = GetComponent<RoomIdentifier>();
        return identifier != null ? identifier.roomID : gameObject.name;
    }

        

        

}