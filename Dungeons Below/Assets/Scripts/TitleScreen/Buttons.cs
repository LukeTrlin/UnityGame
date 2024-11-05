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
    

    void Awake()
    {

      
        
       
        


    }
    public void Begin() // load / restart game
    {
        PlayerController.PauseOpened = false;
        SceneManager.LoadScene(3);
        ResetValues();
        
        Time.timeScale = 1;
        
        pauseMenu.SetActive(false);
    }

    public void Options() // options
    {
        
        SceneManager.LoadScene(4);
          
    }


    public void Resume() // resume
    {
        PlayerController.PauseOpened = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Title() // title
    {
        PlayerController.PauseOpened = false;
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



    public void ResetValues()
    {
        RoomFunctions.CurrentScore = 0;
        BossHealthManager.BossMaxHealth = 1000;
        HealthManager.EnemyMaxHealth = 100;
        PlayerDamageController.PlayerMaxHealth = 100;
        ManaManager.MaxManaAmount = 100;
        PlayerDamageController.SkeletonDamage = 10;
        PlayerDamageController.SlimeDamage = 20;


    }
}
