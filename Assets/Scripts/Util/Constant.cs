using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Constant
{
    // MONSTER 
    public const string LIZZARD = "Attacker/Lizard";
    public const string DRILL = "Attacker/DrillAgent";
    public const string EYEBUG = "Attacker/EyeBug";
    public const string KONG = "Attacker/KongMachine";

    //TOWER
    public const string CACTUS = "CATUS";

    // EFFECT
    public const string POSION = "Posion";

    public static string GetPrefabPath(string name)
    {
        return "Assets/Prefabs/" + name + ".prefab";
    }

    //Config
    public static int NUMBER_LANE = 5;

    //Stats Field
    public const string HEALTH = "HP";
    public const string DAMAGE = "damage";
    public const string SPEED = "speed";
}
