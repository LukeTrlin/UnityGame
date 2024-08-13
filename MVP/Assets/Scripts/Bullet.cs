using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
