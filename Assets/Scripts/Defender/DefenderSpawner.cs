using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IButtonObserver
{
    void onButtonSelect(int idx);
}

public interface ISlotObserver
{
    void onSlotSelect(int idx);
}



class DefenderSpawner : MonoBehaviour, IButtonObserver, ISlotObserver
{
    [SerializeField] DefenderButton currentButton;
    [SerializeField] List<DefenderButton> ListButton;
    //int buttonindex = -1;
    [SerializeField] Transform buttonSpawnParent;
    [SerializeField] float timeSpawnButton = 4f;


    string[] listcards = { Constant.TOWER2, Constant.TOWER1};

    CardFactory _cardFactory = new CardFactory();
    [SerializeField] int maxButton = 5;
    [SerializeField] int maxSlot = 35;
    [SerializeField] List<Slot> ListSlot;

    [SerializeField] Slot slotPref;
    
    public void onButtonSelect(int idx)
    {
        if (idx >= ListButton.Count) 
        {
            return;
        }

        if(currentButton != null)
        {
            currentButton.UnSelect();
        }

        var tempButton = ListButton[idx];
        if(tempButton == null)
        {
            return;
        }
        tempButton.Select();
        currentButton = tempButton;
    }

    public void onSlotSelect(int idx)
    {
        if(idx >= ListSlot.Count)
        {
            //return;
        }
        if(currentButton == null)
        {
            return;
        }

        SetDefender(idx);
        
        // destroy that button and re-sort
    }

    private void SetDefender(int idx)
    {
        ListSlot[idx].SpawnDefender(currentButton.GetDefenderPref());
        ListButton.Remove(currentButton);
        Destroy(currentButton.gameObject);
        ResetButtonIndex();
        currentButton = null;
        //StopCoroutine(ButtonSpawn());
        //StopAllCoroutines();
        //StartCoroutine(ButtonSpawn());
    }

    private void SlotSpawn()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            Slot newSlotGO = Instantiate(slotPref, transform.position, Quaternion.identity);
            newSlotGO.transform.SetParent(this.transform);
            newSlotGO.transform.localScale = Vector3.one;

            newSlotGO.observer = this;
            newSlotGO.index = i;
            ListSlot.Add(newSlotGO);
        }
    }

 

    private void Awake() {
        SlotSpawn();
    }

    private void Start() 
    {
        
                var spawn = StartCoroutine(ButtonSpawn()); 
    }

    IEnumerator ButtonSpawn()
    {
        while(true)
        {
            if (ListButton.Count < maxButton) 
            {
                yield return new WaitForSeconds(2f);
                //spawn
                string cardname = listcards[UnityEngine.Random.Range(0, listcards.Length)];
                var card = GetCard(cardname);
                if (card == null)
                {
                    yield return null;
                }
                var button = card.GetDefenderButton();
                if (button == null)
                {
                    yield return null;
                }
                DefenderButton defenderButton = Instantiate(button, transform.position, Quaternion.identity);
                defenderButton.Card = button.Card;
                defenderButton.transform.parent = buttonSpawnParent;
                defenderButton.transform.localScale = Vector3.one;
                //buttonindex++;
                defenderButton.observer = this;
                defenderButton.index = ListButton.Count;
                ListButton.Add(defenderButton);
                yield return new WaitForSeconds(timeSpawnButton);
                Debug.Log("spawn button");  
            }
            else    
                yield return null;    
        }  
    }

    private void ResetButtonIndex()
    {
        foreach (Transform child in buttonSpawnParent.transform)
        {
            var button = child.GetComponent<DefenderButton>();
            button.index = ListButton.IndexOf(button);
        }
    }


   TowerCard GetCard(string name)
   {
        return _cardFactory.MakeTowerCard(name);
   }
}

