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

    private float ActiveMoveSpeed; // WIP
    public float DashSpeed; // WIP

    private float DashLength = .5f, DashCooldown = 1f; // WIP

    private float DashCounter; // WIP
    private float DashCooldownCounter; // WIP
    
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
        ActiveMoveSpeed = moveSpeed; // active move speed = move speed
        
   
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
        
        // DASH MECHANICS
        
        if (Input.GetKeyDown(KeyCode.Space)) // Is Space Is Pressed Dash
        {
            if (DashCooldownCounter <= 0 && DashCounter <= 0) // If Both condition True
            {
                ActiveMoveSpeed = DashSpeed; // Change Move Speed
                DashCounter = DashLength; // Sets Dash Counter to Dash Length
            }
        }

        // Teleport Test
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.transform.position += new Vector3(0f, 24f, 0f); // Move Player Up
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameObject.transform.position += new Vector3(-40f, 0f, 0f); // Move Player Left
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObject.transform.position += new Vector3(40f, 0f, 0f); // Move Player Right
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.position += new Vector3(0f, -24f, 0f); // Move Player Down
        }

        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime; //  Dash Counter Timer

            if (DashCounter <=0)
            {
                // Allows Dashing
                ActiveMoveSpeed = moveSpeed;
                DashCounter = DashCooldown;
            }
        }
        
        if (DashCooldownCounter > 0)
        {
            DashCooldownCounter -= Time.deltaTime;
        }

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

    

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "TopWall")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.24f,transform.position.z);
        }

        if (collision.gameObject.tag == "BottomWall")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.24f,transform.position.z);
        }

        if (collision.gameObject.tag == "RightWall")
        {
            transform.position = new Vector3(transform.position.x+0.24f, transform.position.y,transform.position.z);
        }

        if (collision.gameObject.tag == "LeftWall")
        {
            transform.position = new Vector3(transform.position.x-0.24f, transform.position.y,transform.position.z);
        }


        
    }

  
     


}
