using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    public Defender defenderPref;
    public Image background;
    


    public void SelectDefenderButton() 
    {
        DefenderController.Instance.SetWhiteOtherButton();
        background.color = Color.green;
        DefenderSpawner.Instance.SetDefenderPref(defenderPref);
    }

   
   
}
