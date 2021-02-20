using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Constant
{
    // MONSTER 
    public static string LIZZARD_PATH = "Attacker/Lizard";

    public static string GetPrefabPath(string name)
    {
        return "Assets/Prefabs/" + name + ".prefab";
    }
}
