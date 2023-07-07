using UnityEngine;

public enum GameState
{
    Home,
    MainMenu,
    Gameplay,
    FinishGame
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public static GameManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gameState = GameState.Home;
    }

    public void ChangGameState(GameState State)
    {
        gameState = State;
    }

    public bool IsGameState(GameState State)
    {
        return gameState == State;
    }
}