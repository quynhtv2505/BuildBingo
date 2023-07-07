using UnityEngine;

public class StateWaiting : IStateMachine
{
    private float timer;
    private float randomTimer;

    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTimer = Random.Range(1f, 1.5f);
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (timer >= randomTimer)
        {
            if (LevelManager.Instance.IsTurnGame(bot.currentState))
            {
                bot.ChangState(new StateSellectBingo());
            }
            else
            {
                bot.ChangState(new StateEatBingo());
            }
        }
    }

    public void OnExit(Bot bot)
    {
    }
}