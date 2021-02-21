using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public interface ICreepObserver
{
    void onCreepDestoyed();
}

public class WaveConfig
{
    //config data
    private int _totalCreep = 0;
    private string[] _creepType = { };
    private int[] _numberCreeps = { };
    private int _spawnMaxDuration = 0;
    private int _maxSpawnLane = 1;
    private int _spawnMultiAfter = 0;

    public WaveConfig(int _totalCreep, string[] _creepType, int[] _numberCreeps,
        int _spawnMaxDuration, int _maxSpawnLane, int _spawnMultiAfter
    )
    {
        this._totalCreep = _totalCreep;
        this._creepType = _creepType;
        this._numberCreeps = _numberCreeps;
        this._spawnMaxDuration = _spawnMaxDuration;
        this._maxSpawnLane = _maxSpawnLane;
        this._spawnMultiAfter = _spawnMultiAfter;
    }

    public int TotalCreep {
        get { return this._totalCreep;  }
    }

    public string[] CreepTypeList
    {
        get { return this._creepType; }
    }

    public int[] CreepDistribution
    {
        get { return this._numberCreeps; }
    }

    /**
     * Duration in Seconds
     */
    public int SpawnMaxDuration
    {
        get { return this._spawnMaxDuration; }
    }

    public int MaxLaneSpawn
    {
        get { return this._maxSpawnLane; }
    }

    public int SpawnMultiAfter
    {
        get { return this._spawnMultiAfter; }
    }
}

public class Wave: ICreepObserver
{
    private WaveConfig _config;

    //current data
    private int _numberCreepLeft = 0;
    private int _numberCreepDestroyed = 0;
    private int[] _listCreepLeft = { };

    /**
     * 
     */
    public Wave(WaveConfig config)
    {
        this._config = config;
        this._numberCreepLeft = config.TotalCreep;
        this._listCreepLeft = config.CreepDistribution;
    }

    public int NumberCreepLeft
    {
        get { return this._numberCreepLeft; }
    }

    public bool IsEndWave
    {
        get { return this._numberCreepDestroyed == this._config.TotalCreep; }
    }

    public void onCreepDestoyed()
    {
        _numberCreepDestroyed++;
    }

    public int SpawnMaxDuration
    {
        get { return this._config.SpawnMaxDuration; }
    }

    public string[] GetNextCreep()
    {
        List<string> nextCreep = new List<string>();
        if(_numberCreepLeft <= 0)
        {
            return nextCreep.ToArray();
        }
        
        if(CanSpawnMulti())
        {
            return selectMultiCreep();
        }

        nextCreep.Add(selectCreep());
        return nextCreep.ToArray();
    }

    protected string[] selectMultiCreep()
    {
        List<string> nextCreep = new List<string>();
        if (_numberCreepLeft <= 0)
        {
            return nextCreep.ToArray();
        }
        
        int numberLane = _numberCreepLeft > Constant.NUMBER_LANE ?
                UnityEngine.Random.Range(1, Constant.NUMBER_LANE) :
                UnityEngine.Random.Range(1, _numberCreepLeft);
        
        for(int i = 0; i < numberLane; i++)
        {
            string creep = this.selectCreep();
            nextCreep.Add(creep);
        }

        return nextCreep.ToArray();
    }

    protected string selectCreep()
    {
        int[] listCreepNonLeft = _listCreepLeft
            .Select((x, idx) => new { Value = x, Index = idx})
            .Where(x => x.Value == 0)
            .Select(x => x.Index)
            .ToArray();
        return _config.CreepTypeList[Array.RandomNumberWithExcept(0, _listCreepLeft.Length - 1, listCreepNonLeft)];
    }

    private bool CanSpawnMulti()
    {
        return _numberCreepLeft <= _config.TotalCreep - _config.SpawnMultiAfter;
    }
}
