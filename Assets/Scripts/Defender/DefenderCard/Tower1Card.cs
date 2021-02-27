using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower1Card : TowerCard
{
    public Tower1Card() : base("Card/Tower1", "Defender/Tower1") { }
}

public class Tower1Factory : ITowerCardFactory
{
    TowerCard ITowerCardFactory.MakeCard()
    {
        return new Tower1Card();
    }
}
