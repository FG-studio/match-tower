using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower2Card : TowerCard
{
    public Tower2Card() : base("Card/Tower2", "Defender/Tower2") { }
}

public class Tower2Factory : ITowerCardFactory
{
    TowerCard ITowerCardFactory.MakeCard()
    {
        return new Tower2Card();
    }
}
