using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{
    public Text lifepointTxt;
    public int LP;

    private void Start() {
        UpdateLP();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        var attacker = collider.GetComponent<Attacker>();
        if (attacker)
        {
            Destroy(attacker.gameObject);
            LP--;
            UpdateLP();
            StartCoroutine(CheckLP());
        }
    }

    private void UpdateLP()
    {
        lifepointTxt.text = LP.ToString();
        
    }

    IEnumerator CheckLP()
    {
        if(LP == 0)
        {
            
            yield return new WaitForSeconds(2f);
            SceneLoader.Instance.LoadEndScene();
        }
    }

}
