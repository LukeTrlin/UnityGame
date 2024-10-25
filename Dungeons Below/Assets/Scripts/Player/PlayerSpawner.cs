using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject ActivePlayer;
    public PlayerHealthManager playerHealthManager;


    // Start is called before the first frame update
    void Start() 
    {
        SummonPlayer();
    }
    void SummonPlayer()
    {
        ActivePlayer = Instantiate(PlayerPrefab);
        ActivePlayer.transform.position = new Vector3(0, 0, 0);
    }
}
