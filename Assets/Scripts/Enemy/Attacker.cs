using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float moveSpeed;
    int damage;
    GameObject currentTarget;
    ICreepObserver creepObserver;

    public void Start()
    {
        var monster = GetComponent<Monster>();
        if (monster)
        {
            var stats = monster.GetStats();
            moveSpeed = stats.Speed;
            damage = stats.Damage;
        }
    }

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
        Monster target = currentTarget.GetComponent<Monster>();
        if (target)
        {
            target.onDamage(damage);
        }
    }

    private void OnDestroy()
    {
        if(creepObserver != null) creepObserver.onCreepDestoyed();
    }
}
