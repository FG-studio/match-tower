using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpawner : MonoBehaviour
{
    public Attacker attackerpref;
    bool spawn = true;
    //public Transform AtkerGroup;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            //System.Random rand = new System.Random();
            yield return new WaitForSeconds(Random.Range(2, 5));

            SpawnAttacker();
        
        }
      
    }


    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate( attackerpref, transform.position, Quaternion.identity);
        newAttacker.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
