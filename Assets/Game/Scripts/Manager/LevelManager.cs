using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.UI;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public enum TurnState
{
    Player,
    Bot1,
    Bot2,
    Bot3
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public TurnState gameTurn;
    public Player player;
    public TargetNumber tarGetNumber;
    public TargetTimer targetTimer;
    public CointManager cointGame;
    public float timer;
    public int countBingo;
    public bool willGamble;
    public int coint;
    public const int winBingo = 5;
    public int gamBle;
    public List<Character> listCharacters = new List<Character>();
    public List<GameObject> postionBot = new List<GameObject>();
    private GameObject posPlayer;

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
        JsonSaveLoad.Instance.LoadData();
        coint = JsonSaveLoad.Instance.cointsJson;
    }

    private void Start()
    {
        //SceneManager.activeSceneChanged += OnGameSceneChanged;
        
        willGamble = false;
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameState(GameState.Gameplay)) return;
        targetTimer.TimerDown();
        if (targetTimer.numberTimer <= 0.1f)
        {
            NextTurn();
            targetTimer.numberTimer = timer;
        }
    }

    public void OnGameSceneChanged(Scene s2, Scene s3)
    {
        //Changed Scene s1 s2
        //GameManager.Instance.ChangGameState(GameState.Gameplay);
        OnInit();
    }

    public void OnInit()
    {
        InitCharacter();
        gameTurn = TurnState.Player;
        tarGetNumber.OnInit();
        targetTimer.OnInit();
        cointGame.OnInit();
        TurnText.Instance.ChangTextTurn();
    }

    public void InitCharacter()
    {
        PosPlayer();
        PosBot();
        player.OnInit();
        List<Color> listColors = new List<Color>()
        {
            Color.green,
            Color.yellow,
            Color.cyan
        };
        for (int i = 0; i < listCharacters.Count; i++)
        {
            listCharacters[i].OnInit();
            listCharacters[i].myBooard.imageTurn.imageTurn.color = listColors[i];
        }
        player.myBooard.imageTurn.imageTurn.color = Color.red;
    }

    private void PosBot()
    {
        listCharacters = new List<Character>();
        postionBot = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject go = GameObject.Find("BotPos" + i);
            postionBot.Add(go);
        }
        int index = 1;
        for (int i = 0; i < 3; i++)
        {
            GameObject gobject = Resources.Load<GameObject>("Bot/Bot");
            GameObject bot = Instantiate(gobject, postionBot[i].transform);
            bot.name = "Bot" + (i + 1);
            Bot bott = bot.GetComponent<Bot>();
            bott.currentState = (TurnState)index;
            listCharacters.Add(bott);
            index++;
        }
    }

    private void PosPlayer()
    {
        GameObject go = GameObject.Find("PlayerPos");
        GameObject gojcet = Resources.Load<GameObject>("Player/Player");

        player = Instantiate(gojcet, go.transform).GetComponent<Player>();
        player.name = "Player";
    }

    protected void ChangTurn(TurnState turnState)
    {
        gameTurn = turnState;
        targetTimer.OnInit();
        TurnText.Instance.ChangTextTurn();
    }

    public bool IsTurnGame(TurnState turnState)
    {
        return gameTurn == turnState;
    }

    public void NextTurn()
    {
        while ((int)gameTurn < 3)
        {
            int index = (int)gameTurn;
            index++;
            ChangTurn((TurnState)index);
            return;
        }

        player.characterStatus = CharacterStatus.MyTurn;
        ChangTurn((TurnState)0);
    }

    public void FinishGame(Character character)
    {
        GameManager.Instance.ChangGameState(GameState.FinishGame);
        if (character == player)
        {
            gamBle *= 3;
            coint += gamBle;
            cointGame.OnInit();
        }
        else
        {
            //gamBle *= 3;
            coint -= gamBle;
            cointGame.OnInit();
        }

        StartCoroutine(nameof(ShowUIFinishGame), character);
    }

    IEnumerator ShowUIFinishGame(Character character)
    {
        yield return new WaitForSeconds(1f);
        JsonSaveLoad.Instance.cointsJson = coint;
        JsonSaveLoad.Instance.SaveData();
        if (character is Player)
        {
            UIManager.Instance.OpenWinGameUI();
            UIManager.winFinishGameUI.TextWin(character);
            SoundManager.Instance.sfxWin.Play();
        }
        else
        {
            UIManager.Instance.OpenLoseGameUI();
            UIManager.loseFinishGameUI.TextWin(character);
            SoundManager.Instance.sfxLose.Play();
        }
    }
}