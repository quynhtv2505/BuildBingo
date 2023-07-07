using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinishGameUi : MonoBehaviour
{
    public Button[] bnts = new Button[2];
    public TextMeshProUGUI textWhoWin;
    public TextMeshProUGUI textScore;
    private void Start()
    {
        Action[] actions = new Action[]
        {
            Claim,
            ClaimADS
        };
        for (int i = 0; i < bnts.Length; i++)
        {
            int index = i;
            bnts[i].onClick.AddListener(actions[index].Invoke);
        }
    }

    public void TextWin(Character character)
    {
        textWhoWin.text = character.gameObject.name;
        textScore.text = character.Score.ToString();
    }

    public void Claim()
    {
        GameManager.Instance.ChangGameState(GameState.MainMenu);
        SceneManager.activeSceneChanged -= LevelManager.Instance.OnGameSceneChanged;
        SceneManager.LoadScene(1);
    }
    public void ClaimADS()
    {
        //Add ads

        GameManager.Instance.ChangGameState(GameState.MainMenu);
        SceneManager.activeSceneChanged -= LevelManager.Instance.OnGameSceneChanged;
        SceneManager.LoadScene(1);
    }
}