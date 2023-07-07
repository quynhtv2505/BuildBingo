public class BlockBot : Block
{
    public override void OnAwake()
    {
        base.OnAwake();
        numberBlock.gameObject.SetActive(false);
    }
}
