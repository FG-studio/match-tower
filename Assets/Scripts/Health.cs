using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    public GameObject deathVFX;
  

    public void DealDamage(int damage)
    {
        HP-=damage;

        if (HP <= 0) 
        {
            TriggerDeathVFX();
            Destroy(this.gameObject);
        }
       
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX) return;
        GameObject thisdeathVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(thisdeathVFX, 1f);
    }
}
