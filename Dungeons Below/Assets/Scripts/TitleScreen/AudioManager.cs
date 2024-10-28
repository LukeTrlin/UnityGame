using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject AudioManagers;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        
        DontDestroyOnLoad(AudioManagers);
        audioSource = AudioManagers.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
