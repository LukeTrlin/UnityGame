using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    private Vector3 mousePos; // Position of cursor
    private Camera mainCam; // Main Camera of Game

    

        
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Finds Main Camera in scene

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // Locates Mouse Position

        Vector3 rotation = mousePos - transform.position; // Rotates Firing point accordingly

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Changes Rotation Z accordingly

        transform.rotation = Quaternion.Euler(0,0, rotZ); // Changes the transform Accordingly
    }
}
