using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public static DefenderController Instance;
    public DefenderButton[] defenderButtonsPref;
    public List<DefenderButton> selectedButtons;
    public Transform buttonSpawnParent;

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
            DefenderButton defender = Instantiate(defenderButtonsPref[0], transform.position, Quaternion.identity);
            defender.transform.parent = buttonSpawnParent;
            defender.transform.localScale = Vector3.one;
            
            selectedButtons.Add(defender);
            yield return new WaitForSeconds(3f);
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
}
