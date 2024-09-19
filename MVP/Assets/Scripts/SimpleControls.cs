using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SimpleControls : MonoBehaviour
{
    public AudioClip music;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DontDestroyOnLoad(music);
            SceneManager.LoadScene(3);
            
        }
    }
}
