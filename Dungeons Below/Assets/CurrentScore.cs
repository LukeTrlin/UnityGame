using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentScore : MonoBehaviour
{

    public TMP_Text pointsText;

      public void Start()
    {
        
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        pointsText.SetText(RoomFunctions.CurrentScore.ToString());
    }
}
