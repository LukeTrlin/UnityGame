using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    // Allows to change scenes quickly
    void Update()
    {
        string CurrentSceneName = SceneManager.GetActiveScene().name;
         

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(CurrentSceneName);
        }
    }
}
