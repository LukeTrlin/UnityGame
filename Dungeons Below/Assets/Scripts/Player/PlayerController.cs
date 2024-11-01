using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour

{
    [SerializeField] GameObject Loading;
    public Vector2 ActiveSpeed;

    public GameObject StaticPlayer;

    public static bool PauseOpened;
    [SerializeField] GameObject pauseMenu; // Pause Menu Object
    

    //movement 
    


    public HealthManager healthManager; // HealthBars

    private ManaManager manaManager; // Mana Bars
    public Image manaBar; // ManaBar Object

    public Transform bulletTransform; // bullet prefab
    public float yRange = 7f;
    public float xRange = 7;

    // Dash variables
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;

   
    private Rigidbody2D rb; // Rigidbody

    public float moveSpeed; // Move Speed
    
    private Vector2 moveDirection; // Direction currently moving

    

    // Attack Variables
    [SerializeField] private Rigidbody2D bulletPrefab; // Bullet Rigidbody
    [SerializeField] private Rigidbody2D secondaryBulletPrefab; // Bullet Rigidbody
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
            if (LoadingScript.IsLoading == false)
            {
                PauseOpened = true;
                 pauseMenu.SetActive(true); // Enable Pause Menu
                Time.timeScale = 0; // Freezes Game

            }
           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Dash");
        }


       

        // PLAYER MOVEMENT
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Determines Move Direction





        // FIRING MECHANICS

        if (Input.GetMouseButtonDown(0)) {
            shoot(); // Sends to shoot function
        }

        else if (Input.GetMouseButtonDown(1)) {
            SecondaryShoot();
        }


        
        
    }

    void FixedUpdate () 
    {
        if (isDashing)
        {
            return;
        }        
        rb.velocity = moveDirection * moveSpeed; // sets rb velocity consistently
        ActiveSpeed = rb.velocity;


    }

   
    
    public void shoot () {

        if (manaManager.ManaAmount >= 20) // check if enough mana
        {
            if (PauseOpened == false)
            {
                if (LoadingScript.IsLoading == false)
                {
                    manaManager.ManaDrain(20); // Drain Mana, Sends to ManaManager
                Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity); // Clones bullet prefab anmd fires
                }
                

            }

        }
    }

    public void SecondaryShoot()
    {
        if (manaManager.ManaAmount >= 100) // checks if 50 mana is available
        {
             if (PauseOpened == false)
            {
                if (LoadingScript.IsLoading == false)
                {
                    manaManager.ManaDrain(100);
                    Instantiate(secondaryBulletPrefab, bulletTransform.position, Quaternion.identity);
                }
                
            }

            
        }
    }

    private IEnumerator Dash() 
    {
        if (manaManager.ManaAmount >= 15)
        {
             if (PauseOpened == false)
             {
                if (LoadingScript.IsLoading == false)
                {
                    isDashing = true;
                rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
                manaManager.ManaDrain(15); // Drain Mana, Sends to ManaManager
                yield return new WaitForSeconds(dashDuration);
                isDashing = false;


                }



                


             }
            
        }
        
    }
}