using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    TowerCard _card;
    public Image background;
    
    public TowerCard Card
    {
        get { return _card; }
        set { _card = value; }
    }

    public void SelectDefenderButton() 
    {
        if(_card == null)
        {
            Debug.LogError("card is not assigned for button");
            return;
        }
        var defenderPref = _card.GetTower();
        if(defenderPref == null)
        {
            Debug.LogError("card not have instance of tower");
            return;
        }
        DefenderController.Instance.SetWhiteOtherButton();
        background.color = Color.green;
        DefenderSpawner.Instance.SetDefenderPref(defenderPref);
    }
}
