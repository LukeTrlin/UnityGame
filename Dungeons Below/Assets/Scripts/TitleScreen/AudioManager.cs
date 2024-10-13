using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject AudioManagers;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(AudioManagers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
