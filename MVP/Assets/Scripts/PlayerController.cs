using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    //movement 
    public float yRange = 9.5f;
    public float xRange = 18f;
    private Rigidbody2D rb;

    public float moveSpeed;

    private float ActiveMoveSpeed;
    public float DashSpeed;

    private float DashLength = .5f, DashCooldown = 1f;

    private float DashCounter;
    private float DashCooldownCounter;
    
    private Vector2 moveDirection;

    // Attack Variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    private Vector2 mousepos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ActiveMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
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

        // MOUSE POSITION
        
        
        // DASH MECHANICS
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCooldownCounter <= 0 && DashCounter <= 0)
            {
                ActiveMoveSpeed = DashSpeed;
                DashCounter = DashLength;
            }
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
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
