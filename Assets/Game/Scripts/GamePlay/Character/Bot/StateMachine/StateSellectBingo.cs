using UnityEngine;

public class StateSellectBingo : IStateMachine
{
    private float timer;
    private float randomTimer;

    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTimer = Random.Range(0.5f, 1f);
        bot.FindNumberTarget(LevelManager.Instance.tarGetNumber.numberTarget);
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer >= randomTimer)
        {
            timer = 0;
            if (LevelManager.Instance.gameTurn == bot.currentState)
            {
                bot.SellectNumberBingo();
                LevelManager.Instance.NextTurn();
                bot.ChangState(new StateEatBingo());
            }
            else
            {
                bot.ChangState(new StateWaiting());
            }
        }
    }

    public void OnExit(Bot bot)
    {
    }
}