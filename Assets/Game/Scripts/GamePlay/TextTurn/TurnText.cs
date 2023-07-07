using TMPro;
using UnityEngine;

public class TurnText : SingleTon<TurnText>
{
    public TextMeshProUGUI textTurn;

    public void ChangTextTurn()
    {
        textTurn.text = LevelManager.Instance.gameTurn.ToString();
        switch (LevelManager.Instance.gameTurn)
        {
            case TurnState.Player:
                textTurn.color = Color.red;
                return;
            case TurnState.Bot1:
                textTurn.color = Color.green;
                return;
            case TurnState.Bot2:
                textTurn.color = Color.yellow;
                return;
            case TurnState.Bot3:
                textTurn.color = Color.cyan;
                return;
        }
    }
}