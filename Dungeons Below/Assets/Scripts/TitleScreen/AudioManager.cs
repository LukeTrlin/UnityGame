using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
      

    // Update is called once per frame
    void Update()
    {
        if (SoundManager.volumeSlider.value > 0)
        {
            audioSource.volume = SoundManager.volumeSlider.value;
        }
    }
}
