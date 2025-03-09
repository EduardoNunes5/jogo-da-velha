using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameBoard : MonoBehaviour
{

    [SerializeField]
    private GameObject moveSlotPrefab;
    [SerializeField]
    private GameObject board;
    [SerializeField]
    private Color boardColor;

    private Image boardImage;

    public Cell[,] Cells { get; private set; }
    public int BoardSize { get; private set; }


    private void Start()
    {
        BoardSize = 3;
        InitiateFields();
        CreateBoard();
    }

    private void InitiateFields()
    {
        boardImage = board.GetComponent<Image>();
        Cells = new Cell[3, 3];
    }

    private void CreateBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var slot = Instantiate(moveSlotPrefab, board.transform);
                var cell = slot.GetComponent<Cell>();
                cell.Position = new(i, j);
                Cells[i, j] = cell;
            }
        }

        boardImage.color = boardColor;
    }

    public void UpdateBoardInteractivity(bool canInteract)
    {
        foreach (var cell in Cells)
        {
            cell.SetInteractable(canInteract);
        }
    }

    public Cell GetRandomAvailableSlot()
    {
        if (IsComplete())
            return null;

        int posX;
        int posY;
        do
        {
            posX = Random.Range(0, BoardSize);
            posY = Random.Range(0, BoardSize);

        } while (Cells[posX, posY].Symbol != null);

        return Cells[posX, posY];
    }

    public bool IsComplete()
    {
        return Cells.Cast<Cell>().All(slot => !IsCellAvailable(slot));
    }

    public bool IsCellAvailable(Cell cell)
    {
        return cell.Symbol == null;
    }
}
