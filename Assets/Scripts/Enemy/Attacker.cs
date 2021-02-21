using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 5f)]
    public float moveSpeed;
    public int damage;
    GameObject currentTarget;
    ICreepObserver creepObserver; 
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("atk", false);
        }
    }

    public void AddObserver(ICreepObserver obs)
    {
        creepObserver = obs;
    }

    public void SetSpeed(float newspeed)
    {
        moveSpeed = newspeed;
    }

    public void Attacking(GameObject target)
    {
        GetComponent<Animator>().SetBool("atk", true);
        currentTarget = target;
    }

    public void DealDamageToTarget()
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    private void OnDestroy()
    {
        if(creepObserver != null) creepObserver.onCreepDestoyed();
    }
}
