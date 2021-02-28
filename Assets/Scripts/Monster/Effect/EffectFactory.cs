using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{
    Dictionary<string, IEffectFactory> _effectMapper = new Dictionary<string, IEffectFactory>();
    private static EffectFactory Instance;
    public static EffectFactory GetInstance()
    {
        if(Instance == null)
        {
            Instance = new EffectFactory();
        }
        return Instance;
    }

    private EffectFactory()
    {
        _effectMapper.Add(Constant.POSION, new PosionEffectFactory());
    }

    public BaseEffect MakeEffect(string effect, IMonsterEffectObserver monster, int duration)
    {
        var factory = _effectMapper[effect];
        if (factory == null)
        {
            return null;
        }
        return factory.MakeEffect(monster, duration);
    }
}
