using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleShooting : MonoBehaviour
{


    

    public float projectileSpeed = 500f;
    public Rigidbody2D bullet;
    public float bulletSpeed;
    public Transform spawnPos;
    Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Transform playerTransform = player.transform;
        rb.velocity = transform.right * playerTransform.localScale.x  * bulletSpeed;
        
    }

 
    void fire()
    {
        Rigidbody2D Fireball = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation) as Rigidbody2D;
        Fireball.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
        

    }







    // Update is called once per frame
    void Update()
    {
    }
    
}


