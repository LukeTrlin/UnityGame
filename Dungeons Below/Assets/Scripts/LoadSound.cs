using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSound : MonoBehaviour
{
    public AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
