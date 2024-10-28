using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject AudioManagers;
    private AudioSource audioSource;
    public GameObject ScriptManager;
    // All Functions for seperate buttons

    [SerializeField] GameObject pauseMenu;
    

    void Awake()
    {
        DontDestroyOnLoad(AudioManagers);
        DontDestroyOnLoad(ScriptManager);
        audioSource = AudioManagers.GetComponent<AudioSource>();
        


    }
    public void Begin() // load / restart game
    {
        SceneManager.LoadScene(3);
        RoomFunctions.CurrentScore = 0;
        HealthManager.BaseDamage = 20;
        HealthManager.SecondaryBaseDamage= 100;
        BossHealthManager.BaseDamageBoss = 2;
        BossHealthManager.SecondaryBaseDamageBoss = 8;
        
        Time.timeScale = 1;
        
        pauseMenu.SetActive(false);
    }

    public void Options() // options
    {
        SceneManager.LoadScene(4);
        
        
    }

    public void Resume() // resume
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Title() // title
    {
        
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
        
        pauseMenu.SetActive(false);
        
    }

    public void Exit() // exit game
    {
        Application.Quit();
        Debug.Log("Game Is Exiting");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }

}
