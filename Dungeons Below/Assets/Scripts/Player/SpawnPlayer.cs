using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Spawning Player");
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
