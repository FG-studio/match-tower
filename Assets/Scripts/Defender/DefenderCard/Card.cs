using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CactusCard : TowerCard
{
    public CactusCard() : base("Card/Cactus", "Defender/Cactus") { }
}

public class CactusFactory : ITowerCardFactory
{
    TowerCard ITowerCardFactory.MakeCard()
    {
        return new CactusCard();
    }
}
