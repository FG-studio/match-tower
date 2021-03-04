using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory
{
    Dictionary<string, ITowerCardFactory> _towerMaper = new Dictionary<string, ITowerCardFactory>();
    public CardFactory()
    {
        _towerMaper.Add(Constant.TOWER2, new Tower2Factory());
        _towerMaper.Add(Constant.TOWER1, new Tower1Factory());
    }

    public TowerCard MakeTowerCard(string tower)
    {
        var factory = _towerMaper[tower];
        if(factory == null)
        {
            return null;
        }
        return factory.MakeCard();
    }
}
