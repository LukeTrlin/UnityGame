using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public GameObject text1;
    public TMP_Text text;
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    // Static flag for managing fading
    public bool isFading = false;

    // Called when the scene is loaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Reset flag when the scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isFading = false; // Reset fading flag when scene is reloaded
    }

    public void SubmitScore()
    {
        if (inputName.text.Length > 0 && inputScore.text != "0")
        {
            text1.SetActive(true);
            submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
            text.color = Color.green;
            text.text = "Successfully uploaded score";
            
            
        }
        else if (inputName.text.Length == 0 && inputScore.text == "0")   
        {
            text.color = Color.red;
            text1.SetActive(true);
            text.text = "You need to input a name and score";
           
            
        }
        else if (inputName.text.Length == 0)   
        {
            text.color = Color.red;
            text1.SetActive(true);
            text.text = "You need to input a name";
           
        }
        else if (inputScore.text == "0")   
        {
            text.color = Color.red;
            text1.SetActive(true);
            text.text = "You need to have a score";
            
        }
    }

   

}