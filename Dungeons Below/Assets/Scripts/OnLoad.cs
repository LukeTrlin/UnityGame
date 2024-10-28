using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
        public GameObject AudioManagers;
    public AudioSource audioSource;
    public GameObject ScriptManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = AudioManagers.GetComponent<AudioSource>();
        audioSource.Stop();
        Debug.Log("Stopping Audio");
    }
}
