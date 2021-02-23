using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerCard
{
    protected string _cardPath = "";
    protected string _towerPath = "";

    public TowerCard(string card, string tower)
    {
        _cardPath = card;
        _towerPath = tower;
    }

    public string CardPrefab
    {
        get { return _cardPath; }
    }

    public string TowerPrefab
    {
        get { return _towerPath; }
    }

    public DefenderButton GetDefenderButton()
    {
        var prefab = PrefabUtility.LoadPrefabContents(Constant.GetPrefabPath(this._cardPath));
        if (!prefab)
        {
            Debug.LogError("prefab is null. Path " + this._cardPath);
            return null;
        }
        var button = prefab.GetComponent<DefenderButton>();
        if (!button)
        {
            Debug.LogError("not have attacker in this prefab: " + this._cardPath);
        }
        button.Card = this;
        Debug.Log("assigned for button done " + button.Card.ToString());
        return button;
    }

    public Defender GetTower()
    {
        var prefab = PrefabUtility.LoadPrefabContents(Constant.GetPrefabPath(this._towerPath));
        if (!prefab)
        {
            Debug.LogError("prefab is null. Path " + this._towerPath);
            return null;
        }
        var defender = prefab.GetComponent<Defender>();
        if (!defender)
        {
            Debug.LogError("not have attacker in this prefab: " + this._towerPath);
        }
        return defender;
    }
} 

public interface ITowerCardFactory
{
    TowerCard MakeCard();
}