using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEnemyController : SteerableBehaviour, IShooter, IDamageable
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
