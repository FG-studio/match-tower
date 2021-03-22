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
        new WaveConfig(20, 
            new List<string>{ Constant.EYEBUG, Constant.KONG }.ToArray(), 
            new List<int>{ 15, 5 }.ToArray(), 
            6, 3, 7 ), 
            //spawnMaxDuration, maxSpawnLane, spawnMultiAfter
        new WaveConfig(50, 
            new List<string>{ Constant.EYEBUG, Constant.KONG, Constant.DRILL }.ToArray(), 
            new List<int>{ 25, 15, 10 }.ToArray(), 
            4, 5, 15 ),
        new WaveConfig(100, 
            new List<string>{ Constant.EYEBUG, Constant.KONG, Constant.DRILL }.ToArray(), 
            new List<int>{ 40, 40, 20 }.ToArray(), 
            3, 7, 50 ),
        new WaveConfig(200, 
            new List<string>{ Constant.EYEBUG, Constant.KONG, Constant.DRILL }.ToArray(), 
            new List<int>{ 70, 50, 80 }.ToArray(), 
            2, 9, 50 ),
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
