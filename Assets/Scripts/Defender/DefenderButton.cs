using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    TowerCard _card;
    public Image background;

    public IButtonObserver observer;
    public int index = -1;
    bool isSelected = false;
    
    public TowerCard Card
    {
        get { return _card; }
        set { _card = value; }
    }

    public Defender GetDefenderPref() 
    {
        

        if(_card == null)
        {
            Debug.LogError("card is not assigned for button");
            return null;
        }

        var defenderPref = _card.GetTower();
        if(defenderPref == null)
        {
            Debug.LogError("card not have instance of tower");
            return null;
        }
        
        return defenderPref;
    }

    public void Select()
    {
        isSelected = true;
        ChangeColorBG();
    }

    public void UnSelect()
    {
        isSelected = false;
        ChangeColorBG();
    }

    private void ChangeColorBG()
    {
        if (isSelected == true)
        {
            background.color = Color.green;
        }
        else
        {
             background.color = Color.white;
        }
    }

    public void OnButtonClick()
    {
        if(index < 0 || observer == null)
        {
             return;
        }
        observer.onButtonSelect(index);
    }
}
