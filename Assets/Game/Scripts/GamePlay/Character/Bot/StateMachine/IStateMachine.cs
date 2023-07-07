
public interface IStateMachine
{
    public void OnEnter(Bot bot);
    public void OnExcute(Bot bot);
    public void OnExit(Bot bot);
}
