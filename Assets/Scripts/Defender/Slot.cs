using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //Defender defenderPref;
    public ISlotObserver observer;
    public int index = -1;
    //[SerializeField] bool isEmpty = true;
    public void SpawnDefender(Defender defPref)
    {   
        
        Defender newdefender = Instantiate(defPref, this.transform.position, Quaternion.identity);
        newdefender.transform.SetParent(this.transform);
        //newdefender.transform.localScale = Vector3.one;
    }

    private bool isEmpty()
    {
        if (transform.childCount == 0)
            return true;
        else
            return false;
    }
    public void OnSlotClick()
    {
        
        if(isEmpty() == false)
        {
            Debug.Log("Slot full");
            return;
        }
        if(index < 0 || observer == null)
        {
            return;
        }

        observer.onSlotSelect(index);
        
    }
}
