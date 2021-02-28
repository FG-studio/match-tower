using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    private int _rawHP;
    private int _rawDamage;
    private float _rawSpeed;

    private int _hp;
    private int _damage;
    private float _speed;

    private IMonsterObserver monster;

    public Stats(IMonsterObserver monster, int hp, int damage, float speed)
    {
        this.monster = monster;
        _rawHP = hp;
        _rawSpeed = speed;
        _rawDamage = damage;

        _hp = hp;
        _speed = speed;
        _damage = damage;
    }

    public void RollBackStats(string field)
    {
        switch (field)
        {
            case Constant.HEALTH:
                _hp = _rawHP;
                break;
            case Constant.SPEED:
                _speed = _rawSpeed;
                break;
            case Constant.DAMAGE:
                _damage = _rawDamage;
                break;
            default: break;
        }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public void OnDamaged(int value)
    {
        _hp -= value;
        Debug.Log("current hp " + _hp);
        if(_hp <= 0) {
            Debug.Log("onDeath");
            monster.OnDeath();
        }
    }
}
