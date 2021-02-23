using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //Defender defenderPref;

    public void SpawnDefender()
    {   
            if(this.transform.childCount == 0)
            {
                DefenderSpawner.Instance.PlaceDefender(this.transform);
                Debug.Log("Button ok");
                
            }
            else 
                return;

    }
}
