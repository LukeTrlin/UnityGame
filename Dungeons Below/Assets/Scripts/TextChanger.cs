using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TextChanger : MonoBehaviour
{
    public TMP_Text text;
    public bool isTrue = true;
    // Start is called before the first frame update
    void Update()
    {
        if (isTrue == true)
        {
            isTrue = false;
            StartCoroutine("ChangeText");
        }
        
    }

    public IEnumerator ChangeText()
    {
        
        yield return new WaitForSeconds(1);
        text.text = "Loading.";
        yield return new WaitForSeconds(1);
        text.text = "Loading..";
        yield return new WaitForSeconds(1);
        text.text = "Loading...";
        isTrue = true;


    }
}
