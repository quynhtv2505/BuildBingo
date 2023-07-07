using UnityEngine;

public class TargetTimer : ABTarget
{
    public float numberTimer;


    public override void OnAwake()
    {
        LevelManager.Instance.targetTimer = this;
    }

    public void OnInit()
    {
        numberTimer = LevelManager.Instance.timer;
    }

    public void TimerDown()
    {
        numberTimer -= Time.deltaTime;
        ViewNumber();
    }

    public override void ViewNumber()
    {
        base.ViewNumber();
        int i = Mathf.RoundToInt(numberTimer);
        textNumberTarget.text = i.ToString();
    }
}