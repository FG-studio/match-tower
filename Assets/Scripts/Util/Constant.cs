using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Constant
{
    // MONSTER 
    public static string LIZZARD = "Attacker/Lizard";
    public static string DRILL = "Attacker/DrillAgent";
    public static string EYEBUG = "Attacker/EyeBug";
    public static string KONG = "Attacker/KongMachine";

    //TOWER
    public static string TOWER2 = "Tower2";
    public static string TOWER1 = "Tower1";

    public static string GetPrefabPath(string name)
    {
        return "Assets/Prefabs/" + name + ".prefab";
    }

    //Config
    public static int NUMBER_LANE = 5;
}
