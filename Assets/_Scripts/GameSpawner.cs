using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSpawner : MonoBehaviour
{
  GameManager gm;

    public GameObject Player;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir()
    {
        

        if (gm.gameState == GameManager.GameState.GAME)
        {
            Vector3 posicao = new Vector3(0, 0);
            Instantiate(Player, posicao, Quaternion.identity, transform);

        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

}
