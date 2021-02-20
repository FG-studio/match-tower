using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject projectile;
    public Transform GunPos;
    public AtkSpawner myLaneSpawner;
    Animator Defenderanim;
    
    private void Start() {
        Defenderanim = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update() {
        if (IsAttackerInLane())
        {
            //TODO change anim to state shooter
            Defenderanim.SetBool("atk", true);
        }
        else
        {
            //TODO change anim to state idle
            Defenderanim.SetBool("atk", false);
        }
    }


    public void Fire()
    {
        if(!projectile) return;
        GameObject newprojectile = Instantiate(projectile, GunPos.position, Quaternion.identity);
        newprojectile.transform.parent = this.transform;
        Destroy(newprojectile, 5f);
    }

    private void SetLaneSpawner()
    {
        AtkSpawner[] spawners = FindObjectsOfType<AtkSpawner>();
        foreach (AtkSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)  <= 0.4);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    private bool IsAttackerInLane()
    {
        //if my lane spawner child count less/equal to zero => return false
        // else true
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
            
    }
}
