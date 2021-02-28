using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PositionEffect : BaseEffect
{
    private int baseDamage = 10;

    public PositionEffect(IMonsterEffectObserver monster, int duration): base(monster, Constant.POSION, duration) { }

    public override void Active(int value = 0)
    {
        if(value != 0)
        {
            baseDamage = value;
        }
        StartTimer();
    }

    public override void Effected(object source, ElapsedEventArgs e)
    {
        if(_timeleft <= 0)
        {
            StopTimer();
            _monsterEffected.OnEffectEnd(Name);
            return;
        }

        _timeleft--;
        if (_monsterEffected == null)
        {
            return;
        }
        _monsterEffected.GetStats().OnDamaged(baseDamage);
    
    }
}

public class PosionEffectFactory : IEffectFactory
{
    public BaseEffect MakeEffect(IMonsterEffectObserver monster, int duration)
    {
        return new PositionEffect(monster, duration);
    }
}
