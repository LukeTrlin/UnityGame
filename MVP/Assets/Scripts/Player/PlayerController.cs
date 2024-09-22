using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour

{
    public Vector2 ActiveSpeed;

    public GameObject StaticPlayer;
    [SerializeField] GameObject pauseMenu; // Pause Menu Object

    //movement 
    


    public HealthManager healthManager; // HealthBars

    private ManaManager manaManager; // Mana Bars
    public Image manaBar; // ManaBar Object

    public Transform bulletTransform; // bullet prefab
    public float yRange = 7f;
    public float xRange = 7;
   
    private Rigidbody2D rb; // Rigidbody

    public float moveSpeed; // Move Speed
    
    private Vector2 moveDirection; // Direction currently moving

    // Attack Variables
    [SerializeField] private Rigidbody2D bulletPrefab; // Bullet Rigidbody
    [SerializeField] private Rigidbody2D bulletPrefab2; // Bullet Rigidbody
    [SerializeField] private Transform firingPoint; // Firing Point Location

    // Damage Variables

    void Start()
    {
        manaManager = manaBar.GetComponent<ManaManager>(); // Finds Mana Manager
        rb = GetComponent<Rigidbody2D>(); // Converts Rigidbody into rb for ease of access
        
   
    }

    // Update is called once per frame
    void Update()

    {   
     

        if (Input.GetKeyDown(KeyCode.Escape)) // If Escape is pressed
        {
            pauseMenu.SetActive(true); // Enable Pause Menu
            Time.timeScale = 0; // Freezes Game
        }

       

        // PLAYER MOVEMENT
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Determines Move Direction





        // FIRING MECHANICS

        if (Input.GetMouseButtonDown(0)) {
            shoot(); // Sends to shoot function
        }


        
        
    }

    void FixedUpdate () 
    {
        rb.velocity = moveDirection * moveSpeed; // sets rb velocity consistently
        ActiveSpeed = rb.velocity;

    }

   
    
    public void shoot () {

        if (manaManager.ManaAmount >= 20) // check if enough mana
        {
            manaManager.ManaDrain(20); // Drain Mana, Sends to ManaManager
            Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity); // Clones bullet prefab anmd fires
        }
    }
}
