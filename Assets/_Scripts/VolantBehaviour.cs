using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate()
    {  
    }
}
