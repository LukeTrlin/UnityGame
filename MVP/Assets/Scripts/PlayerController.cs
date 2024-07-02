using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float yRange = 7.5f;
    public float xRange = 17.25f;
    private Rigidbody2D rb;

    public float moveSpeed;

    private float ActiveMoveSpeed;
    public float DashSpeed;

    private float DashLength = .5f, DashCooldown = 1f;

    private float DashCounter;
    private float DashCooldownCounter;
    
    private Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ActiveMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

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

    }

    void FixedUpdate () 
    {
        rb.velocity = moveDirection * moveSpeed;
    }
    
}
