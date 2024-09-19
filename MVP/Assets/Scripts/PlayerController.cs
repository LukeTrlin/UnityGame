using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour

{
    [SerializeField] GameObject pauseMenu;

    //movement 

    private ManaManager manaManager;
    public Image manaBar;

    public Transform bulletTransform;
    public float yRange = 7f;
    public float xRange = 7f;
    private Rigidbody2D rb;

    public float moveSpeed;

    private float ActiveMoveSpeed;
    public float DashSpeed;

    private float DashLength = .5f, DashCooldown = 1f;

    private float DashCounter;
    private float DashCooldownCounter;
    
    private Vector2 moveDirection;

    // Attack Variables
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform firingPoint;

    // Damage Variables


    
    // Start is called before the first frame update
    void Start()
    {
        manaManager = manaBar.GetComponent<ManaManager>();
        rb = GetComponent<Rigidbody2D>();
        ActiveMoveSpeed = moveSpeed;
        
   
    }

    // Update is called once per frame
    void Update()
    {   


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

       
        // PLAYER MOVEMENT

        if (transform.position.x > xRange) {

            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yRange) {

            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if (transform.position.y < -yRange) {

            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.x < -xRange) {

            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        // DASH MECHANICS
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCooldownCounter <= 0 && DashCounter <= 0)
            {
                ActiveMoveSpeed = DashSpeed;
                DashCounter = DashLength;
            }
        }

        // Teleport Test
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.transform.position += new Vector3(0f, 24f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameObject.transform.position += new Vector3(-40f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObject.transform.position += new Vector3(40f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.position += new Vector3(0f, -24f, 0f);
        }

        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime;

            if (DashCounter <=0)
            {
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
            shoot();
        }
    }

    void FixedUpdate () 
    {
        rb.velocity = moveDirection * moveSpeed;
    }

   
    
    public void shoot () {

        if (manaManager.ManaAmount >= 20)
        {
            manaManager.ManaDrain(20);
            Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);
        }
        
        
        

    }


}
