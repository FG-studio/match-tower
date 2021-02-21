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
        new WaveConfig(5, new List<string>{ Constant.LIZZARD, Constant.EYEBUG }.ToArray(), 
                            new List<int>{ 2, 3 }.ToArray(), 5, 3, 7 ),
        new WaveConfig(
            50, 
            new List<string>{ Constant.EYEBUG, Constant.KONG, Constant.DRILL }.ToArray(), 
            new List<int>{ 25, 15, 10 }.ToArray(), 
            4, 5, 15 ),
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
