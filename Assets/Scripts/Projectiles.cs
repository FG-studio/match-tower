using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] int projectileSpeed;

    [SerializeField] int effectValue;

    private void Update() {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }


    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetEffectValue(int value)
    {
        this.effectValue = value;
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        var collattacker = collider.GetComponent<Attacker>(); 
        var target = collider.GetComponent<Monster>();

        if (collattacker && target)
        {
            Destroy(this.gameObject);
            target.onDamage(damage);

            //use effect
            //var effect = EffectFactory.GetInstance().MakeEffect(Constant.POSION, target, 2);
            //target.onDamage(damage, effect, effectValue);
        }
    }

    public void SetSpeed(int newspeed)
    {
        projectileSpeed = newspeed;
    }
}
