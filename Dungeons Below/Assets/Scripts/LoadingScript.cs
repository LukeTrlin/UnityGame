using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject PlayerUI;
    public GameObject Slider;
    public GameObject Text;
    public GameObject audioSource;

    public static bool IsLoading = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        IsLoading = true;
        PlayerUI.SetActive(false);
        Text.SetActive(true);
        Slider.SetActive(true); 
        LoadingScreen.SetActive(true);
        StartCoroutine("Waiter");


    }
    
    public IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        LoadingScreen.SetActive(false);
        Text.SetActive(false);
        Slider.SetActive(false);
        PlayerUI.SetActive(true);
        Instantiate(audioSource);
        IsLoading = false;

    }
}
