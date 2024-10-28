using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public Slider slider;
    private bool IsTrue = false;

    private bool CanPlay = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        StartCoroutine("ChangeValue");
    }

    // Update is called once per frame
    void Update()
    {
       


        if (IsTrue == true)
        {
            slider.value = slider.value + 0.02f;
            StartCoroutine("Waiter");
            
        }

       

        
       
    }


    public IEnumerator ChangeValue()
    {
        yield return new WaitForSeconds(2);
        IsTrue = true;
    }
     public IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        
    }
}
