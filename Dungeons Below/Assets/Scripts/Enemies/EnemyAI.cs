using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour
{
    private Transform target;
    private Transform randomTarget;
    public float speed;
    public bool EnemyAggro;
    private RoomFunctions roomFunctions;
        // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Find target
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 5) // Detects if the player is within 5(?) of the player
        {
        EnemyAggro = true; // Sets the enemy aggro bool to true
        }

        if (EnemyAggro == true) // If the enemy aggro bool is true (player is detected), move the enemy towards the player
        {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Move to Target
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "SecondaryBullet")
        {
            EnemyAggro = true; // Sets the aggro to true when the enemy takes damage
        }
    }
}
