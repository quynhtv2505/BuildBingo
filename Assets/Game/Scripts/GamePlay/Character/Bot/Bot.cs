using System;
using Game.Scripts.GamePlay.Board;
using UnityEngine;
using UnityEngine.UI;


public class Bot : Character
{
    public IStateMachine stateMachine;

    public override void OnInit()
    {
        base.OnInit();
        ChangState(new StateWaiting());
        characterStatus = CharacterStatus.MyTurn;
        GameObject go = Resources.Load<GameObject>("Board/Panel-BoardBot");
        myBooard = Instantiate(go, transform).GetComponent<Board>();
        myBooard.content = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        myBooard.OnInit(this);
        myBooard.content.GetComponent<GridLayoutGroup>().cellSize = new Vector2(37.79f, 41.1f);
        myBooard.imageTurn.StartCooldow();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        ExcuteState();
    }

    public void ChangState(IStateMachine state)
    {
        if (this.stateMachine != null)
        {
            this.stateMachine.OnExit(this);
        }

        this.stateMachine = state;
        if (this.stateMachine != null)
        {
            this.stateMachine.OnEnter(this);
        }
    }

    private void ExcuteState()
    {
        if (stateMachine != null)
        {
            this.stateMachine.OnExcute(this);
        }
    }

    public void SellectNumberBingo()
    {
        int index = myBooard.listBlocks.IndexOf(ChoseBlock());


        SoundManager.Instance.sfxBnts.Play();
        int num = myBooard.listBlocks[index].number;
        LevelManager.Instance.tarGetNumber.numberTarget = num;
        LevelManager.Instance.tarGetNumber.SetNumberTarget(num);
        LevelManager.Instance.tarGetNumber.ViewNumber();
        myBooard.listBlocks[index].ChangStateBlock();
        if (IsBingo(myBooard.listBlocks[index]))
        {
            SoundManager.Instance.sfxLineBingo.Play();
        }
        myBooard.listBlocks.Remove(myBooard.listBlocks[index]);
    }

    public void FindNumberTarget(int index)
    {
        for (int i = 0; i < myBooard.listBlocks.Count; i++)
        {
            if (myBooard.listBlocks[i].number == index)
            {
                myBooard.listBlocks[i].spark1x1.Play();
                myBooard.listBlocks[i].ChangStateBlock();
                if (IsBingo(myBooard.listBlocks[i]))
                {
                    SoundManager.Instance.sfxLineBingo.Play();
                }
                myBooard.listBlocks.Remove(myBooard.listBlocks[i]);
                SoundManager.Instance.sfxBnts.Play();
                break;
            }
        }
    }
    protected Block ChoseBlock()
    {
        int count = Int32.MinValue;
        Block block = null;
        for (int i = 0; i < myBooard.listBlocks.Count; i++)
        {
            int maxCount = CountWeightBlock(myBooard.listBlocks[i]);

            if (maxCount > count)
            {
                count = maxCount;
                block = myBooard.listBlocks[i];
            }
        }
        Score += count;
        return block;
    }
}