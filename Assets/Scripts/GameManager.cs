using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public BoardManager BoardManager;
    public PlayerController PlayerController;
    private int m_FoodAmount = 100;

    public UIDocument UIDoc;
    private Label m_FoodLabel;

    public static GameManager Instance { get; private set; }

    public TurnManager TurnManager { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager();
        TurnManager.OnTick += OnTurnHappen;

        BoardManager.Init();
        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1));

        m_FoodLabel = UIDoc.rootVisualElement.Q<Label>("FoodLabel");
        m_FoodLabel.text = "Food : " + m_FoodAmount;
    }

    void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        m_FoodLabel.text = "Food : " + m_FoodAmount;
    }
}