using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaManager : MonoBehaviour
{
    public Image ManaBar;
    public float ManaAmount = 100f;
    public float ManaRegenAddPerSecond = +5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mana Regeneration
        
        ManaRestore(0.1f);
       

       

    }
    

    public void ManaDrain(float damage)
    {
        ManaAmount -= damage;
        ManaBar.fillAmount = ManaAmount / 100f;
    }

    public void ManaRestore(float ManaRestore)
    {
        ManaAmount += ManaRestore;
        ManaAmount = Mathf.Clamp(ManaAmount, 0, 100);

        ManaBar.fillAmount = ManaAmount / 100;
    }

    

}
