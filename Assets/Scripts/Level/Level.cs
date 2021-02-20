using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    Wave NextWave();
}

public class Level: ILevel
{
    protected WaveConfig[] listWave = {
        new WaveConfig(20, new List<string>{ Constant.LIZZARD }.ToArray(), new List<int>{ 20 }.ToArray(), 5, 3, 4 ),
        new WaveConfig(
            30, 
            new List<string>{ Constant.LIZZARD }.ToArray(), 
            new List<int>{ 20 }.ToArray(), 
            4, 
            4, 
            2 ),
    };
    protected int currentWave = 0;


    public Wave NextWave()
    {
        if(currentWave >= listWave.Length)
        {
            return null;
        }
        WaveConfig config = listWave[currentWave];
        currentWave++;

        return new Wave(config);
    }
}
