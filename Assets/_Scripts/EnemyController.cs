using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
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

    float angle = 0;

    private void FixedUpdate()
    {
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        Thrust(x, y);
       
    }
}
