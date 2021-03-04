using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public static DefenderController Instance;
    public DefenderButton[] defenderButtonsPref;
    public List<DefenderButton> selectedButtons;
    public Transform buttonSpawnParent;

    string[] listcards = { Constant.TOWER2, Constant.TOWER1};

    CardFactory _cardFactory = new CardFactory();

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        StartCoroutine(ButtonSpawn());
    }

    IEnumerator ButtonSpawn()
    {
        while (buttonSpawnParent.transform.childCount < 5)
        {
            yield return new WaitForSeconds(1f);
            //spawn
            string cardname = listcards[Random.Range(0, listcards.Length)];
            var card = GetCard(cardname);
            if (card == null)
            {
                yield return null;
            }
            var button = card.GetDefenderButton();
            if (button == null)
            {
                yield return null;
            }
            DefenderButton defender = Instantiate(button, transform.position, Quaternion.identity);
            defender.Card = button.Card;
            defender.transform.parent = buttonSpawnParent;
            defender.transform.localScale = Vector3.one;
            
            selectedButtons.Add(defender);
            yield return new WaitForSeconds(5f);
        }
    }

    public void SetWhiteOtherButton()
    {
        foreach(DefenderButton button in selectedButtons)
        {
            button.background.color = Color.white; 
        }
    }

    public void DestroySelectedButton()
    {
        
        foreach(DefenderButton button in selectedButtons)
        {
            if(button.background.color == Color.green)
            {
                Destroy(button.gameObject);
                selectedButtons.Remove(button);
                
                StopAllCoroutines();
                StartCoroutine(ButtonSpawn());
                
            }
        }
    }

   TowerCard GetCard(string name)
   {
        return _cardFactory.MakeTowerCard(name);
   }
}
