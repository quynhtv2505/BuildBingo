using UnityEngine.UI;
using System;

public class BlockPlayer : Block
{
    public Button bntClickNumber;
    public override void OnAwake()
    {
        base.OnAwake();
        bntClickNumber = GetComponent<Button>();
        bntClickNumber.onClick.AddListener(SellectNumber);
    }
    public void SellectNumber()
    {
        if (
            LevelManager.Instance.IsTurnGame(TurnState.Player) && !isSellect)
        {
            SoundManager.Instance.sfxBnts.Play();

            LevelManager.Instance.tarGetNumber.SetNumberTarget(number);
            LevelManager.Instance.tarGetNumber.ViewNumber();
            LevelManager.Instance.player.characterStatus = CharacterStatus.Waiting;
            LevelManager.Instance.player.Score += LevelManager.Instance.player.CountWeightBlock(this);
            myBoard.listBlocks.Remove(this);
            ChangStateBlock();
            if (myBoard.myCharacter.IsBingo(this))
            {
                SoundManager.Instance.sfxLineBingo.Play();
            }
            LevelManager.Instance.NextTurn();
        }
        else return;

        //if want Test Bingo
       // myBoard.listBlocks.Remove(this);
       // ChangStateBlock();
       
       
       
        // if want find bingo

        // else if (!LevelManager.Instance.IsTurnGame(TurnState.Player) &&
        //          number == LevelManager.Instance.tarGetNumber.numberTarget)
        // {
        //     ChangStateBlock();
        // }
    }
}