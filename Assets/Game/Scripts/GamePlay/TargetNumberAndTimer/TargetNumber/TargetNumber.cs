public class TargetNumber : ABTarget
{
    public int numberTarget;

    public override void OnAwake()
    {
        LevelManager.Instance.tarGetNumber = this;
    }

    public void OnInit()
    {
        textNumberTarget.text = "None";
    }

    public override void ViewNumber()
    {
        base.ViewNumber();
        textNumberTarget.text = numberTarget.ToString();
    }

    public void SetNumberTarget(int number)
    {
        numberTarget = number;
    }
}