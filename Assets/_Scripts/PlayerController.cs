using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    private int lifes;
    Animator animator;
    GameManager gm;
    private void Start()
    {
        animator = GetComponent<Animator>();
        lifes = 10;
        gm = GameManager.GetInstance();
    }

    public AudioClip shootSFX;

    void FixedUpdate()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        if(Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }


        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        

        
    }
    public GameObject bullet;
    public Transform arma01;
    public float shootDelay = 0.001f;
    private float _lattShootTimestamp = 0.0f;
    public void Shoot()
    {   
        if (Time.time - _lattShootTimestamp < shootDelay) return;
       _lattShootTimestamp = Time.time;
        AudioManager.PlaySFX(shootSFX);
        Instantiate(bullet, arma01.transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.vidas--;
        if (gm.vidas <= 0) Die();
    }

    public void Die()
    {
        if(gm.gameState == GameManager.GameState.GAME)
        {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        // Destroy(gameObject);
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Debug.Log($"Vida");
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    
}
