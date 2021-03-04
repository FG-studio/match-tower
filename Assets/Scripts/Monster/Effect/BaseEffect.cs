using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public interface IMonsterEffectObserver
{
    Stats GetStats();
    void OnEffectEnd(string name);
}

public interface IEffectFactory
{
    BaseEffect MakeEffect(IMonsterEffectObserver monster, int duration);
}

public abstract class BaseEffect
{
    protected IMonsterEffectObserver _monsterEffected;
    protected int _duration;
    protected int _timeleft;
    protected Timer aTimer;
    private string _name;

    public BaseEffect(IMonsterEffectObserver monster, string name, int duration = -1)
    {
        _monsterEffected = monster;
        _duration = duration;
        _timeleft = duration;
        _name = name;

        aTimer = new Timer();
        aTimer.Elapsed += new ElapsedEventHandler(Effected);
        aTimer.Interval = 1000;
    }

    public string Name
    {
        get { return _name; }
    }

    public void Deactive()
    {
        this.StopTimer();
    }

    public abstract void Active(int value = 0);
    public abstract void Effected(object source, ElapsedEventArgs e);

    protected void StartTimer()
    {
        aTimer.Start() ;
    }

    protected void StopTimer()
    {
        aTimer.Stop();
    }
}
