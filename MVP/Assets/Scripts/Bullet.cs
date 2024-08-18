using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;



    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 5f;

    

    // Start is called before the first frame update
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }
}
