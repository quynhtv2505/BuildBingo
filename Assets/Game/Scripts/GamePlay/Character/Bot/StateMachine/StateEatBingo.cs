using UnityEngine;

public class StateEatBingo : IStateMachine
{
    private float timer;
    private float randomTimer;

    public void OnEnter(Bot bot)
    {
        timer = 0;
        randomTimer = Random.Range(0f, 2f);
        // Bot sellect bingo now
        bot.FindNumberTarget(LevelManager.Instance.tarGetNumber.numberTarget);
    }

    public void OnExcute(Bot bot)
    {
        timer += Time.deltaTime;
        if (LevelManager.Instance.IsTurnGame(bot.currentState))
        {
            bot.ChangState(new StateSellectBingo());
        }

        if (timer >= randomTimer)
        {
            //bot.FindNumberTarget(LevelManager.Instance.tarGetNumber.numberTarget);

            bot.ChangState(new StateWaiting());
        }
    }

    public void OnExit(Bot bot)
    {
    }
}