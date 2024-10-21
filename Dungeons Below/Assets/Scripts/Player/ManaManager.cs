using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaManager : MonoBehaviour
{
    public Image ManaBar; // mana bar
    public float ManaAmount = 100f; // Max Mana
     
    void FixedUpdate()
    {
        // Mana Regeneration
        
        ManaRestore(0.5f); // Constant 0.5 mana regen per frame // RESET TO 0.5 BEFORE SUBMISSION
       

       

    }
    

    public void ManaDrain(float manacost) // Mana Drain Function
    {
        ManaAmount -= manacost; // Subtract manacost from mana
        ManaBar.fillAmount = ManaAmount / 100f; // update manabar
    }

    public void ManaRestore(float ManaRestore) // mana restore function
    {
        ManaAmount += ManaRestore; // adds mana restore amount to mana
        ManaBar.fillAmount = ManaAmount / 100f;
        ManaAmount = Mathf.Clamp(ManaAmount, 0, 100); // updates mana amount
        

         // updates manabar
    }

    

}
