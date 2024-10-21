using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossEnemyAI : MonoBehaviour
{
    private Transform target;
    private Transform randomTarget;
    public float speed;
    private RoomFunctions roomFunctions;
        // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Find target
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Move to Target
    }
}
