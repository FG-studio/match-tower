using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public static DefenderSpawner Instance;
    [SerializeField] Defender defPref;
    public Slot slotPref;
    public int slotnumber;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        SetUpSlotSpawner();
    }

    private void SetUpSlotSpawner()
    {
        for (int i = 0; i< slotnumber; i++)
        {
            Slot slotGO = Instantiate(slotPref, transform.position, Quaternion.identity);
            slotGO.transform.SetParent(this.transform);
            slotGO.transform.localScale = Vector3.one;
        }
    }

    public Defender SetDefenderPref(Defender defenderselected)
    {
        defPref = defenderselected;
        return defPref;
    }

    public void PlaceDefender(Transform slot)
    {
        if (defPref)
        {
             Defender newdefender = Instantiate(defPref, slot.position, Quaternion.identity);
            newdefender.transform.SetParent(slot);
            //newdefender.transform.localScale = Vector3.one;
            defPref = null;
            DefenderController.Instance.DestroySelectedButton();
        }
       
    }
}
