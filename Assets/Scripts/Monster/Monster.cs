using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMonsterObserver, IMonsterEffectObserver
{
    [SerializeField] int HP;
    [SerializeField] float speed;
    [SerializeField] int damage;
    Dictionary<string, BaseEffect> listEffecting = new Dictionary<string, BaseEffect>();
    Stats stats;

    bool isDestroy = false;
    public GameObject deathVFX;

    public void Awake()
    {
        stats = new Stats(this, HP, damage, speed);
    }

    public void OnDeath()
    {
        this.isDestroy = true;
    }

    public void Update()
    {
        if (isDestroy)
        {
            DestroyObject();
        }
    }

    public void onDamage(int value, BaseEffect effect = null, int effectValue = 0)
    {
        stats.OnDamaged(value); 
        if(effect == null || effect.Name == "")
        {
            return;
        }

        if (listEffecting.ContainsKey(effect.Name))
        {
            return;
        }

        listEffecting.Add(effect.Name, effect);
        effect.Active(effectValue);
    }

    public Stats GetStats()
    {
        return stats;
    }

    public void OnEffectEnd(string name)
    {
        if (listEffecting[name] != null)
        {
            listEffecting.Remove(name);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX) return;
        GameObject thisdeathVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(thisdeathVFX, 1f);
    }

    private void DeactiveAllEffect()
    {
        foreach (KeyValuePair<string, BaseEffect> entry in listEffecting)
        {
            entry.Value.Deactive();
        }
        listEffecting.Clear();
    }

    private void DestroyObject()
    {
        try
        {
            TriggerDeathVFX();
            DeactiveAllEffect();
            Destroy(this.gameObject);
        }
        catch (System.Exception e)
        {
            Debug.LogError("destroy error " + e);
        }
    }
}
