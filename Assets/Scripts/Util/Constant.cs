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
    public static string CACTUS = "CATUS";

    public static string GetPrefabPath(string name)
    {
        return "Assets/Prefabs/" + name + ".prefab";
    }

    //Config
    public static int NUMBER_LANE = 5;
}
