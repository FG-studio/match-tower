using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public float projectileSpeed;

    private void Update() {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
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
            return;
            //Destroy(this.gameObject, 5f);
    }

    public void SetSpeed(float newspeed)
    {
        projectileSpeed = newspeed;
    }
}
