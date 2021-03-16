using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RovingEnemyController : SteerableBehaviour, IDamageable
{   
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        // IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        // if (!(damageable is null))
        // {
        //     damageable.TakeDamage();
        // }
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        gm.pontos++;
        Destroy(gameObject);
    }
}
