using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AtkSpawner : MonoBehaviour
{
    //public Attacker attackerpref;

    public void SpawnAttacker(string prePath, ICreepObserver creepObserver)
    {

        try
        {
            var prefab = Resources.Load<Attacker>(prePath);
            if(!prefab)
            {
                Debug.LogError("prefab is null. Path " + prePath);
                return;
            }
            var attacker = prefab.GetComponent<Attacker>();
            if (!attacker)
            {
                Debug.LogError("not have attacker in this prefab: " +  prePath);
            }
            Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
            newAttacker.AddObserver(creepObserver);
            newAttacker.transform.parent = this.transform;
            //newAttacker.transform.localScale = Vector3.one;
        }
        catch (Exception e)
        {
            Debug.LogError("error when get attacker prefab " + e);
        }
    }
}
