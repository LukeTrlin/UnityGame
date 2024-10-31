using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaManager : MonoBehaviour
{
    public Image ManaBar; // mana bar
    public float ManaAmount; // Max Mana
    public static float MaxManaAmount = 100;

    void Start ()
    {
        ManaAmount = MaxManaAmount;
    }
     
    void FixedUpdate()
    {
        // Mana Regeneration
        
        ManaRestore(0.65f); // Constant 0.65 mana regen per frame // RESET TO 0.65 BEFORE SUBMISSION
       

       

    }
    

    public void ManaDrain(float manacost) // Mana Drain Function
    {
        ManaAmount -= manacost; // Subtract manacost from mana
        ManaBar.fillAmount = ManaAmount / MaxManaAmount; // update manabar
    }

    public void ManaRestore(float ManaRestore) // mana restore function
    {
        ManaAmount += ManaRestore; // adds mana restore amount to mana
        ManaBar.fillAmount = ManaAmount / MaxManaAmount;
        ManaAmount = Mathf.Clamp(ManaAmount, 0, MaxManaAmount); // updates mana amount
        

         // updates manabar
    }

    

}
