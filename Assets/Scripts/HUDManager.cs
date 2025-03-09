using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerSymbolUi, computerSymbolUi, gameInfo;

    [SerializeField]
    private Button playAgainButton;

    public void SetUpPlayerSymbolsByHumanSymbol(MoveEnum humanSymbol)
    {
        playerSymbolUi.text = humanSymbol.ToString();

        if(humanSymbol == MoveEnum.X)
            computerSymbolUi.text = MoveEnum.O.ToString();
        else
            computerSymbolUi.text = MoveEnum.X.ToString();
    }

    public void ChangeCurrentTurn(string currentPlayer)
    {
        string info = "Vez: " + currentPlayer;
        gameInfo.text = info;
    }

    public void ShowWinner(string winner)
    {
        string winnerText = winner + "\n" + "Ganhou!";
        gameInfo.text = winnerText;
    }

    public void ShowDraw()
    {
        gameInfo.text = "Empatou!";
    }

    public void ShowPlayAgainButton()
    {
        playAgainButton.gameObject.SetActive(true);
    }

}
