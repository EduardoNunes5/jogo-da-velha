using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Cell : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI symbolUi;

    private GameManager gameManager;
    private Button button;

    public MoveEnum? Symbol { get; private set; }
    public Vector2Int Position { get; set; }

    private void Start()
    {
        button = GetComponent<Button>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void UpdateText(MoveEnum move)
    {
        if (Symbol != null)
            return;

        Symbol = move;
        symbolUi.text = Symbol.ToString(); 
    }

    public void SetInteractable(bool canInteract)
    {
        button.interactable = canInteract;
    }

    public void Click()
    {
        gameManager.MakeMove(this);
    }

}
