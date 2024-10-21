using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // All Functions for seperate buttons

    [SerializeField] GameObject pauseMenu;
    public AudioClip music;

    
    public void Begin() // load / restart game
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Options() // options
    {
        SceneManager.LoadScene(4);
        DontDestroyOnLoad(music);
        
    }

    public void Resume() // resume
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Title() // title
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
    }

    public void Exit() // exit game
    {
        Application.Quit();
        Debug.Log("Game Is Exiting");
    }

}
