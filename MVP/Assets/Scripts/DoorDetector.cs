using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "TopDoor")
        {
            gameObject.transform.position += new Vector3(0f, 20f, 0f);
        }

        if (collision.gameObject.tag == "LeftDoor")
        {
            gameObject.transform.position += new Vector3(-32.5f, 0f, 0f);
        }
        
        if (collision.gameObject.tag == "RightDoor")
        {
            gameObject.transform.position += new Vector3(32.5f, 0f, 0f);
        }
        
        if (collision.gameObject.tag == "BottomDoor")
        {
            gameObject.transform.position += new Vector3(0f, -20f, 0f);
        }
    }
}
