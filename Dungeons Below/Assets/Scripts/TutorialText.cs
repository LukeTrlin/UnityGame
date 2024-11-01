using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    public TMP_Text text;

    public bool detector = false;
    public bool detector2 = false;
    public bool detector3 = false;

    public bool detector4 = false;

    public bool detector5 = false;


    public GameObject enemy;
    public HealthManager SkeletonHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadText");
        SkeletonHealthManager = enemy.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E))
        {
            if (detector == true)
            {
                detector = false;
                StartCoroutine("LoadText2");
                
            }

        }


         if (Input.GetMouseButtonDown(0)) 
         {
            if (detector2 == true)
            {
                detector2 = false;
                

                StartCoroutine("LoadText3");
                
            }
         }

         
         if (Input.GetMouseButtonDown(1)) 
         {
            if (detector4 == true)
            {
                detector4 = false;
                

                StartCoroutine("LoadText4");
                
            }
         }


         if (SkeletonHealthManager.HealthAmount <= 0)
         {
            if (detector3 == true)
            {
                detector3 = false;
                StartCoroutine("LoadText5");
            }
            
         }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (detector5 == true)
            {
                detector5 = false;
                StartCoroutine("LoadText6");
                
            }

        }

    }

    public IEnumerator LoadText()
    {
        text.text = "Welcome to Dungeons Below";
        yield return new WaitForSeconds(3);
        text.text = "To begin, use WASD to move around";
        yield return new WaitForSeconds(1);
        detector = true;
    }


    public IEnumerator LoadText2()
    {
        
        yield return new WaitForSeconds (3);
        text.text = "Next Click the left mouse button to fire";
        yield return new WaitForSeconds (1);
        detector2 = true;

        
    }
    public IEnumerator LoadText3()
    {
        text.text = "Now Press Right Click to fire a massive attack";
        yield return new WaitForSeconds(1);
        detector4 = true;


        

    }
     public IEnumerator LoadText4()
    {
        yield return new WaitForSeconds (3);
        text.text= "To aim, move your cursor where you want to fire";
        yield return new WaitForSeconds (3);
        text.text= "Try Killing this Enemy!";
        detector3 = true;
        enemy.SetActive(true);

    }

    public IEnumerator LoadText5()
    {
        yield return new WaitForSeconds (3);
        text.text= " Nice! Now press SPACEBAR to dash the direction you are facing";
        yield return new WaitForSeconds (1);
        detector5 = true;
        

    }

    public IEnumerator LoadText6()
    {
        yield return new WaitForSeconds (3);
        text.text= "When Attacking and Dashing, the blue bar will go down, that is called your mana";
        yield return new WaitForSeconds (5);
        text.text= "If you don't have enough mana you can't attack/dodge";
        yield return new WaitForSeconds (5);
        text.text= "Your Health will go down when you are attacked";
        yield return new WaitForSeconds (5);
        text.text= "You will gain health for clearing rooms, and killing a boss";
        yield return new WaitForSeconds (5);
        text.text= "Every floor, your overall health and mana will increase";
        yield return new WaitForSeconds (5);
        text.text= "For Every room cleared, you get 1 score, for a boss room, you get 3";
        yield return new WaitForSeconds (5);
        text.text= "Beware, Difficulty scales with every floor";
        yield return new WaitForSeconds (5);
        text.text= "Congratulations you have passed Dungeons Below 101";
        yield return new WaitForSeconds (5);
        text.text= "I wish you good luck on your adventure!";
        yield return new WaitForSeconds (5);
        SceneManager.LoadScene(3);

    }

    
}
