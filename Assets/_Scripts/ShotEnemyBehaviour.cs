using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{

    private Vector3 direction;

    private int extra_size = 10;

    GameManager gm;

    private Vector2 leftBottom;
    private Vector2 rightTop;
    private SpriteRenderer spriteRenderer;
    private Vector2 spriteSize;
    private Vector2 spriteHalfSize;


  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("Inimigos")) return;

      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }
      Destroy(gameObject);
  }

  void Start()
  {
      Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
      direction =  (posPlayer - transform.position).normalized;
      gm = GameManager.GetInstance();

      leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightTop   = Camera.main.ViewportToWorldPoint(Vector3.one);
 
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize     = spriteRenderer.bounds.size;
        spriteHalfSize = spriteRenderer.bounds.extents;
  }

  void Update()
  {
        // Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        // direction =  (posPlayer - transform.position).normalized;
        if (gm.gameState == GameManager.GameState.ENDGAME){
            Destroy(gameObject);
        }
        if (gm.gameState == GameManager.GameState.MENU){
            Destroy(gameObject);
        }
        if (gm.gameState != GameManager.GameState.GAME) return;
        Thrust(direction.x, direction.y);

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

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}