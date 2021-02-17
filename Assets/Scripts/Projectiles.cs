using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public int projectSpeed;

    private void Update() {
        transform.Translate(Vector2.right * Time.deltaTime * projectSpeed);
    }



    private void OnTriggerEnter2D(Collider2D collider) {
        var collattacker = collider.GetComponent<Attacker>(); 
        var collhealth = collider.GetComponent<Health>();

        if (collattacker && collhealth)
        {
            Destroy(this.gameObject);
            collhealth.DealDamage(damage);
            
        }
        else
            Destroy(this.gameObject, 5f);
    }
}
