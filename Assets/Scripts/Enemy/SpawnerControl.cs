using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] List<AtkSpawner> listSpawner = new List<AtkSpawner>();
    Level level = new Level();
    Wave wave;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("atkSpawner");
        foreach (var obj in listObject)
        {
            AtkSpawner spawnerTmp = obj.GetComponent<AtkSpawner>();
            if (spawnerTmp == null) continue;
            listSpawner.Add(spawnerTmp);
        }
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        Debug.Log("start wave");
        GetNextWave();
        while (true)
        {
            //FIXME: something wrong with there, it not run to end level;
            if (wave == null)
            {
                Debug.Log("end level");
                StopCoroutine("StartWave");
                yield return null;
            }
            if(wave.NumberCreepLeft == 0)
            {
                Debug.Log("not have creep left, not spawn anything else");
                yield return null;
            }
            if(wave.IsEndWave)
            {
                Debug.Log("last creep is destroyed, next wave incoming");
                GetNextWave();
                yield return new WaitForSeconds(5);
            }
            yield return new WaitForSeconds(Random.Range(2, wave.SpawnMaxDuration));
            SpawnAttacker();
        }
    }

    private void GetNextWave()
    {
        wave = level.NextWave();
    }

    private void SpawnAttacker()
    {
        if(listSpawner.Count <= 0) { return; }
        if(wave == null) { return; }
        string[] listCreep = wave.GetNextCreep();
        if (listCreep.Length <= 0) return;
        foreach(var creep in listCreep)
        {
            //FIXME: why last lane not spawn
            int idxOfSpawner = Random.Range(0, listSpawner.Count);
            AtkSpawner spawner = listSpawner[idxOfSpawner];
            spawner.SpawnAttacker(Constant.GetPrefabPath(creep), wave);
        }
        //Debug.Log("wave left: " + wave.NumberCreepLeft);
    }
}
