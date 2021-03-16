
using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void VoltarMenu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
