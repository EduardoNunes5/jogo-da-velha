using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HUDManager), typeof(GameBoard), typeof(SceneLoader))]
public class GameManager : MonoBehaviour
{
    private static readonly int maxTurnsCount = 9;

    [SerializeField]
    private MoveEnum playerSymbol;

    private HUDManager hudManager;
    private GameBoard board;
    private SceneLoader sceneLoader;
    private MoveEnum currentTurn;
    private int turnsCount;
    private bool gameOver;

    private void Start()
    {
        turnsCount = 0;
        currentTurn = playerSymbol;
        hudManager = GetComponent<HUDManager>();
        board = GetComponent<GameBoard>();
        sceneLoader = GetComponent<SceneLoader>();
        gameOver = false;
        hudManager.SetUpPlayerSymbolsByHumanSymbol(playerSymbol);
        hudManager.ChangeCurrentTurn("Jogador");
    }

    public void MakeMove(Cell cell)
    {
        if (!board.IsCellAvailable(cell))
            return;

        FillCell(cell);
        ProcessMove("Jogador");

        if (gameOver)
            return;

        ToggleTurnSymbol();

        StartCoroutine(TakeComputerTurn());
    }

    public void ReloadScene()
    {
        sceneLoader.ReLoadScene();
    }

    private void ToggleTurnSymbol()
    {
        if (currentTurn == MoveEnum.X)
            currentTurn = MoveEnum.O;
        else
            currentTurn = MoveEnum.X;
    }

    private IEnumerator TakeComputerTurn()
    {
        board.UpdateBoardInteractivity(false);
        string currentPlayer = "Computador";
        hudManager.ChangeCurrentTurn(currentPlayer);
        yield return new WaitForSeconds(1);

        DecideComputerMove();
        ProcessMove(currentPlayer);

        if (gameOver)
            yield break;

        ToggleTurnSymbol();

        board.UpdateBoardInteractivity(true);
        hudManager.ChangeCurrentTurn("Jogador");
    }

    private void DecideComputerMove()
    {
        Cell computerMove = board.GetRandomAvailableSlot();
        FillCell(computerMove);
    }

    private void FillCell(Cell cell)
    {
        cell.UpdateText(currentTurn);
        turnsCount++;
    }

    private void ProcessMove(string player)
    {
        if (IsWinner(currentTurn))
        {
            hudManager.ShowWinner(player);
            gameOver = true;
        }

        if (!gameOver && IsDraw())
        {
            hudManager.ShowDraw();
            gameOver = true;
        }

        if(gameOver)
        {
            hudManager.ShowPlayAgainButton();
            board.UpdateBoardInteractivity(false);
        }
    }

    private bool IsWinner(MoveEnum symbol)
    {
        return IsWinnerUsingColumns(symbol) || IsWinnerUsingLines(symbol) || IsWinnerUsingDiagonals(symbol);
    }

    private bool IsDraw()
    {
        return turnsCount == maxTurnsCount;
    }

    private bool IsWinnerUsingColumns(MoveEnum symbol)
    {
        Cell[,] cells = board.Cells;

        for (int i = 0; i < board.BoardSize; i++)
        {
            int count = 0;
            for (int j = 0; j < board.BoardSize; j++)
            {
                if (cells[i, j].Symbol == symbol)
                {
                    count++;
                }
            }

            if (count == 3)
                return true;
        }

        return false;
    }

    private bool IsWinnerUsingLines(MoveEnum symbol) {
        Cell[,] cells = board.Cells;

        for (int i = 0; i < board.BoardSize; i++)
        {
            int count = 0;
            for (int j = 0; j < board.BoardSize; j++)
            {
                if (cells[j, i].Symbol == symbol)
                {
                    count++;

                }
            }
            if (count == 3)
                return true;
        }

        return false;
    }

    private bool IsWinnerUsingDiagonals(MoveEnum symbol) {
        Cell[,] cells = board.Cells;

        int mainDiagonalCount = 0;
        int secondaryDiagonalCount = 0;

        for (int i = 0; i < board.BoardSize; i++)
        {
            if (cells[i,i].Symbol == symbol)
                mainDiagonalCount++;

            if (cells[i, board.BoardSize - i - 1].Symbol == symbol)
                secondaryDiagonalCount++; 
            
        }

        return mainDiagonalCount == 3 || secondaryDiagonalCount == 3;
    }
}
