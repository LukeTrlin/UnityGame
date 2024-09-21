using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Vector3 mousePos; // mouse Position
    private Camera mainCam; // Main Cam
    private Rigidbody2D rb; // defines RB
    public float force; // the force of bullet

    public PlayerController PlayerController;



    [SerializeField] private float speed = 5f; // rate it fires
    [SerializeField] private float lifeTime = 5f; // how long it lives

    

  
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Finds the Camera

        rb = GetComponent<Rigidbody2D>(); // defines Rb
        Destroy(gameObject, lifeTime); // Destroys Bullet after set conditions
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // Finds Mouse Pos
        Vector3 direction = mousePos - transform.position; // Changes Bullet Direction
        Vector3 rotation = transform.position - mousePos; //  Changes Bullet Rotation
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force * speed; // Changes Velocity of bullet
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Changes Rotation
        transform.rotation = Quaternion.Euler(0,0, rot + 90); // Applies Rotation
    }

    void OnTriggerEnter2D(Collider2D collision) // Detects Collision
    {
    
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Skeleton") // If It Collides with enemy
        {
           Destroy(gameObject); // Destroy Bullet
        }




    }
}
