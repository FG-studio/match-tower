using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AtkSpawner : MonoBehaviour
{
    //public Attacker attackerpref;

    public void SpawnAttacker(string prePath)
    {

        try
        {
            var prefab = PrefabUtility.LoadPrefabContents(prePath);
            if(!prefab)
            {
                Debug.LogError("prefab is null. Path " + prePath);
                return;
            }
            Debug.Log("got a prefab");
            var attacker = prefab.GetComponent<Attacker>();
            if (!attacker)
            {
                Debug.LogError("not have attacker in this prefab: " +  prePath);
            }
            Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
            newAttacker.transform.parent = this.transform;
        }
        catch (Exception e)
        {
            Debug.LogError("error when get attacker prefab " + e);
        }
    }
}
