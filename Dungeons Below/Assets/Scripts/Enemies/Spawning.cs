using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Spawning : MonoBehaviour
{
    public bool CanSpawn; // Determines if the enemies are able to spawn

    public GameObject skeletonEnemy; // Skeleton gameobject

    public GameObject slimeEnemy;// Slime gameobject
    public GameObject player; // player gameobject
    public HealthManager SkeletonHealthManager; // Health manager for skeleton
    public HealthManager SlimeHealthManager; // Health manager for slime

    private GameObject ActiveSkeletonEnemy; // The active skeleton enemy
    private GameObject ActiveSlimeEnemy; // The active skeleton enemy
    

    private HealthManager healthManager; // Health Manager
    public Image HealthBar; // HealthBar
    public float HealthAmount = 100f; // Health Amount


    [SerializeField] private int SkeletonAmount;
    private int SlimeAmount;

    public RoomFunctions roomFunctions;
    // Start is called before the first frame update
    void Start()
    {
        roomFunctions = player.GetComponent<RoomFunctions>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Functions to call to spawn enemies
    public void SpawnSkeleton()
    {
    ActiveSkeletonEnemy = Instantiate(skeletonEnemy); // Creates the skeleton enemy in the scene
    SkeletonHealthManager = ActiveSkeletonEnemy.GetComponent<HealthManager>(); // Health manager
    ActiveSkeletonEnemy.transform.position = new Vector3(player.transform.position.x -5, player.transform.position.y, player.transform.position.z); // Determines where the enemy spawns
    HealthBar = SkeletonHealthManager.HealthBar;
    SkeletonAmount -= 1;
    }

    public IEnumerator SpawnNewSkeleton()
    {
    SpawnSkeleton(); // Call the method to spawn a new skeleton
    yield return new WaitForSeconds(1); // Wait before spawning the new skeleton
    SkeletonAmount -= 1;
    }

    public void SpawnSlime()
    {
    ActiveSlimeEnemy = Instantiate(slimeEnemy);
    ActiveSlimeEnemy.transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z);
    SlimeHealthManager = ActiveSlimeEnemy.GetComponent<HealthManager>();
    HealthBar = SlimeHealthManager.HealthBar;
    }

    private string GetCurrentRoomKey()
    {
    // Generate a unique key for the current room
    RoomIdentifier identifier = GetComponent<RoomIdentifier>();
    return identifier != null ? identifier.roomID : gameObject.name;
    }
}
