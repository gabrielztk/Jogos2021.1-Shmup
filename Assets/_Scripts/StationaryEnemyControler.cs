using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyControler : SteerableBehaviour, IDamageable
{
    GameManager gm;
    private int extra_size = 0;

    private Vector2 leftBottom;
    private Vector2 rightTop;
    private SpriteRenderer spriteRenderer;
    private Vector2 spriteSize;
    private Vector2 spriteHalfSize;

    private void Start()
    {
        gm = GameManager.GetInstance();

        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightTop   = Camera.main.ViewportToWorldPoint(Vector3.one);
 
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize     = spriteRenderer.bounds.size;
        spriteHalfSize = spriteRenderer.bounds.extents;
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


    private void Update()
    {

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        // get the sprite's edge positions
        float spriteLeft   = transform.position.x - spriteHalfSize.x;
        float spriteRight  = transform.position.x + spriteHalfSize.x;
        float spriteBottom = transform.position.y - spriteHalfSize.y;
        float spriteTop    = transform.position.y + spriteHalfSize.y;

        // if any of the edges surpass the camera's bounds,
        // set the position TO the camera bounds (accounting for sprite's size)
        if(spriteLeft < leftBottom.x - extra_size)
        {
            Destroy(gameObject);
        }
        else if(spriteRight > rightTop.x + extra_size)
        {
            Destroy(gameObject);
        }

        if(spriteTop < leftBottom.y - extra_size)
        {
            Destroy(gameObject);
        }
        else if(spriteTop > rightTop.y + extra_size)
        {
            Destroy(gameObject);
        }
       
    }
}
