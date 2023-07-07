using Game.Scripts.GamePlay.Board;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Block : MonoBehaviour
{
    public ParticleSystem spark1x1;
    public TextMeshProUGUI numberBlock;
    public Image blockImage;
    public Animator animBlock;
    public int number;
    public int xPos;
    public int yPos;
    public bool isSellect;
    public int weight;
    protected bool isFade;
    protected Board myBoard;
    protected float timer = 2f;
    private void Awake()
    {
        blockImage = GetComponent<Image>();
        OnAwake();
   
    }

    public virtual void OnAwake()
    {
        GameObject go = Resources.Load<GameObject>("FX/Spark1x1");
        spark1x1 = Instantiate(go, transform).GetComponent<ParticleSystem>();
        animBlock = GetComponent<Animator>();

    }
    private void Update()
    {
        if (!isFade) return;
        float coloCurent = blockImage.color.r;
        float coTarget = Color.red.r;
        if (Mathf.Abs(coTarget - coloCurent) < 0.01f) return;
        blockImage.color = Color.Lerp(blockImage.color, Color.red, timer * Time.deltaTime);
    }

    public void InitNumber(int num, int index, Board board)
    {
        myBoard = board;
        number = num;
        numberBlock.text = number.ToString();
        transform.name = transform + " " + index;
        isSellect = false;
        isFade = false;
    }

    public void ChangStateBlock()
    {
        isFade = true;
        isSellect = true;
        spark1x1.Play();
        myBoard.CheckBlock();
    }

    public void CheckWeigh()
    {
        weight = 10;
        if (xPos == yPos)
        {
            weight += 5;
        }

        if (yPos + xPos == 4)
        {
            weight += 5;
        }
    }
}