using System.Timers;
using Game.Scripts.GamePlay.Board;
using UnityEngine;

public class Player : Character
{
    private float timer;
    public override void OnInit()
    {
        base.OnInit();
        timer = 0;
        GameObject go = Resources.Load<GameObject>("Board/Panel-BoardPlayer");
        myBooard = Instantiate(go, transform).GetComponent<Board>();
        myBooard.content = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        myBooard.OnInit(this);
        myBooard.imageTurn.StartCooldow();
        characterStatus = CharacterStatus.MyTurn;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (LevelManager.Instance.IsTurnGame(TurnState.Player))
        {
        }
        else
        {
            if (timer >= 0.5f)
            {
                for (int i = 0; i < myBooard.listBlocks.Count; i++)
                {
                    if (myBooard.listBlocks[i].number == LevelManager.Instance.tarGetNumber.numberTarget)
                    {
                        SoundManager.Instance.sfxBnts.Play();
                        myBooard.listBlocks[i].ChangStateBlock();
                        if (IsBingo(myBooard.listBlocks[i]))
                        {
                            SoundManager.Instance.sfxLineBingo.Play();
                        }
                        myBooard.listBlocks.Remove(myBooard.listBlocks[i]);
                        timer = 0;
                    }
                } 
            }
            
        }
        timer += Time.deltaTime;
    }
}