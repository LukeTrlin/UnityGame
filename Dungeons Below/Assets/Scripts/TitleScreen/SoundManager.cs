using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public Slider Music;

    public Slider Effects;
    public Slider volumeSlider;

    public AudioSource shoot;
    public AudioSource die;
    public AudioSource RoomCharm;

    public AudioSource MusicSound;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        if(!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", 1);
            Load();
        }

        if(!PlayerPrefs.HasKey("overallVolume"))
        {
            PlayerPrefs.SetFloat("overallVolume", 1);
            Load();
        }




        else
        {
            Load();
        }
    }



    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveOverall();
    }

    public void ChangeMusic()
    {
        MusicSound.volume = Music.value;
        SaveMusic();
    }

    public void ChangeEffects()
    {
        die.volume = Effects.value;
        shoot.volume = Effects.value;
        RoomCharm.volume = Effects.value;
        SaveEffects();
    }


    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("overallVolume");
        Effects.value = PlayerPrefs.GetFloat("effectsVolume");
        Music.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveOverall()
    {
        PlayerPrefs.SetFloat("overallVolume", volumeSlider.value);
       
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", Music.value);
    }


    private void SaveEffects()
    {
      
        PlayerPrefs.SetFloat("effectsVolume", Effects.value);
       
    }
    
}
