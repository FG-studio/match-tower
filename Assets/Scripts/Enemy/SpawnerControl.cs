using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    bool spawn = true;
    List<AtkSpawner> listSpawner = new List<AtkSpawner>();
    // Start is called before the first frame update
    IEnumerator Start()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("atkSpawner");
        foreach (var obj in listObject)
        {
            AtkSpawner spawnerTmp = obj.GetComponent<AtkSpawner>();
            if (spawnerTmp == null) continue;
            listSpawner.Add(spawnerTmp);
        }
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        if(listSpawner.Count <= 0) { return; }
        int idxOfSpawner = Random.Range(0, listSpawner.Count - 1);
        AtkSpawner spawner = listSpawner[idxOfSpawner];
        spawner.SpawnAttacker(Constant.GetPrefabPath(Constant.LIZZARD_PATH));
    }
}
