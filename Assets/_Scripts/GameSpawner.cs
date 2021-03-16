using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSpawner : MonoBehaviour
{
  GameManager gm;
  Vector3 pos;

    public GameObject waypointEnemy;
    public GameObject rocktEnemy;
    public GameObject spaceShiptEnemy;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        if (gm.gameState == GameManager.GameState.GAME)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 posicao = new Vector3(Random.Range(-5.0f, 2.0f), Random.Range(1.0f, 15.0f));
            pos = playerPosition + posicao;
            Instantiate(waypointEnemy, pos, Quaternion.identity, transform);
            posicao = new Vector3(Random.Range(3.0f, 10.0f), Random.Range(-7.0f, 7.0f));
            pos = playerPosition + posicao;
            Instantiate(rocktEnemy, pos, Quaternion.identity, transform);
            posicao = new Vector3(Random.Range(3.0f, 10.0f), Random.Range(-7.0f, 7.0f));
            pos = playerPosition + posicao;
            Instantiate(spaceShiptEnemy, pos, Quaternion.identity, transform);

        }
    }

    public float waypointSpawnDelay = 1.0f;
    private float _lattWaypointSpawnTimestamp = 0.0f;
    private bool waypointSpawnRight = true;


    public float rockSpawnDelay = 3.0f;
    private float _lattRockSpawnTimestamp = 0.0f;
    private bool rockSpawnRight = true;


    public float spaceShipSpawnDelay = 6.0f;
    private float _lattSpaceShipSpawnTimestamp = 0.0f;
    private bool spaceShipSpawnRight = true;

    Vector3 posicao;
    
    
    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        if (gm.gameState == GameManager.GameState.GAME && (Time.time - _lattWaypointSpawnTimestamp > waypointSpawnDelay)) {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lattWaypointSpawnTimestamp = Time.time;

            if (waypointSpawnRight) {
                waypointSpawnRight = false;
                posicao = new Vector3(Random.Range(-5.0f, 2.0f), Random.Range(1.0f, 15.0f));
            } else {
                waypointSpawnRight = true;
                posicao = new Vector3(Random.Range(-18.0f, 11.0f), Random.Range(1.0f, 15.0f));
            }
            
            playerPosition += posicao;
            Instantiate(waypointEnemy, playerPosition, Quaternion.identity, transform);
        }

        if (gm.gameState == GameManager.GameState.GAME && (Time.time - _lattRockSpawnTimestamp > rockSpawnDelay)) {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lattRockSpawnTimestamp = Time.time;

            if (rockSpawnRight) {
                rockSpawnRight = false;
                posicao = new Vector3(Random.Range(3.0f, 10.0f), Random.Range(-7.0f, 7.0f));
            } else {
                rockSpawnRight = true;
                posicao = new Vector3(Random.Range(-10.0f, -3.0f), Random.Range(-7.0f, 7.0f));
            }

            playerPosition += posicao;
            Instantiate(rocktEnemy, playerPosition, Quaternion.identity, transform);
        }

        if (gm.gameState == GameManager.GameState.GAME && (Time.time - _lattSpaceShipSpawnTimestamp > spaceShipSpawnDelay)) {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            _lattSpaceShipSpawnTimestamp = Time.time;

            if (spaceShipSpawnRight) {
                spaceShipSpawnRight = false;
                posicao = new Vector3(Random.Range(3.0f, 10.0f), Random.Range(-7.0f, 7.0f));
            } else {
                spaceShipSpawnRight = true;
                posicao = new Vector3(Random.Range(-10.0f, -3.0f), Random.Range(-7.0f, 7.0f));
            }

            playerPosition += posicao;
            Instantiate(spaceShiptEnemy, playerPosition, Quaternion.identity, transform);
        }


    }

}
