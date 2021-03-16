using UnityEngine;

public class StatePatrulhaPorWaypoints : State
{
    public Transform[] waypoints;  
    Rigidbody2D rb;
    GameManager gm;
    
    public override void Awake()
    {
        base.Awake();
        // Configure a transição para outro estado aqui.
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void Start()
    {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        gm = GameManager.GetInstance();
    }

    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if(Vector3.Distance(transform.position, waypoints[1].position) > .1f) {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            rb.MovePosition(rb.position + new Vector2(direction.x, direction.y) * Time.fixedDeltaTime * 2);
        } else {
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }
    }
 
}