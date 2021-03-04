using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        GameObject otherObject = collider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attacking(otherObject);
            
        }
    }
}
