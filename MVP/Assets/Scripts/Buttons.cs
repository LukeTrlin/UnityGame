using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public AudioClip music;
    public void Begin()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
        DontDestroyOnLoad(music);
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Title()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Is Exiting");
    }

}
