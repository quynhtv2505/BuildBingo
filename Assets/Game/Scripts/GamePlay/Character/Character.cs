using System.Collections.Generic;
using Game.Scripts.GamePlay.Board;
using UnityEngine;


public enum CharacterStatus
{
    Waiting,
    MyTurn
}

public abstract class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public TurnState currentState;
    public CharacterStatus characterStatus;
    public Board myBooard;
    protected Dictionary<int, int> dicWeight = new Dictionary<int, int>();
    protected int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameState(GameState.Gameplay)) return;
        OnUpdate();
    }

    public virtual void OnInit()
    {
        for (int i = 0; i < 6; i++)
        {
            dicWeight.Add(i, ReadJson.Instance.SellectBotConfig((int)currentState, i));
        }
    }
    public virtual void OnUpdate()
    {
        if (LevelManager.Instance.IsTurnGame(currentState))
        {
            myBooard.imageTurn.UpdateCooldow();
        }
        else
        {
            myBooard.imageTurn.StartCooldow();
        }
    }
    public int CountWeightBlock(Block block)
    {
        int count = block.weight;
        int countRow = 0;
        int countCollum = 0;
        int countRight = 0;
        int countLeft = 0;
        int sumCount = 0;

        myBooard.blockCheck[block.xPos, block.yPos].isSellect = true;


        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[i, block.yPos].isSellect)
            {
                countRow++;
                count += 6;
            }
        }

        sumCount += dicWeight[countRow];

        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[block.xPos, i].isSellect)
            {
                countCollum++;
                count += 6;
            }
        }

        sumCount += dicWeight[countCollum];

        if (block.yPos == block.xPos)
        {
            for (int i = 0; i < 5; i++)
            {
                if (myBooard.blockCheck[i, i].isSellect)
                {
                    countLeft++;
                    count += 6;
                }
            }
        }

        sumCount += dicWeight[countLeft];

        int index = 4;
        if (block.xPos + block.yPos == 4)
        {
            for (int i = 0; i < 5; i++)
            {
                if (myBooard.blockCheck[index, i].isSellect)
                {
                    countRight++;
                    count += 6;
                }
                index--;
            } 
        }
       

        sumCount += dicWeight[countRight];
        // check Line Bingo if 5 line always > 4 Line
        int countSums = CheckCountLineBingo();
        switch (countSums)
        {
            case 0:
                sumCount += dicWeight[countSums];
                break;
            case 1:
                sumCount *=dicWeight[countSums];
                break;
            case 2:
                sumCount *= dicWeight[countSums];
                break;
            case 3:
                sumCount *= dicWeight[countSums];
                break;
            case 4:
                sumCount *= dicWeight[countSums];
                break;
            case 5:
                sumCount *= dicWeight[countSums];
                break;
            default:
                break;
        }
        myBooard.blockCheck[block.xPos, block.yPos].isSellect = false;
        count += sumCount;
        return count;
    }
    protected int CheckCountLineBingo()
    {
        int count = CountCollum() + CountRow() + CountLeft() + CountRight();
        return count;
    }
    protected int CountCollum()
    {
        int collumCount = 0;
        for (int i = 0; i < 5; i++)
        {
            int index = 0;
            for (int j = 0; j < 5; j++)
            {
                if (myBooard.blockCheck[j, i].isSellect)
                {
                    index++;
                }
            }
            if (index >= LevelManager.winBingo)
            {
                collumCount++;
            }
        }
        return collumCount;
    }
    protected int CountRow()
    {
        int rowCount = 0;
        for (int i = 0; i < 5; i++)
        {
            int index = 0;
            for (int j = 0; j < 5; j++)
            {
                if (myBooard.blockCheck[i, j].isSellect)
                {
                    index++;
                }
            }
            if (index >= LevelManager.winBingo)
            {
                rowCount++;
            }
        }
        return rowCount;
    }
    protected int CountLeft()
    {

        int iCount = 0;
        int leftCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[i, i].isSellect)
            {
                iCount++;
            }
        }
        if (iCount >= LevelManager.winBingo)
        {
            leftCount++;
        }
        return leftCount;
    }
    protected int CountRight()
    {
        int rigtCount = 0;
        int indexDown = 4;
        int iCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[i, indexDown].isSellect)
            {
                iCount++;
            }
            indexDown--;
        }
        if (iCount >= LevelManager.winBingo)
        {
            rigtCount++;
        }
        return rigtCount;
    }

    public bool IsBingo(Block block)
    {
        int row = 0;
        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[block.xPos, i].isSellect)
            {
                row++;
            }
        }
        if (row >= LevelManager.winBingo) return true;

        int collum = 0;
        for (int i = 0; i < 5; i++)
        {
            if (myBooard.blockCheck[i, block.yPos].isSellect)
            {
                collum++;
            }
        }

        if (collum >= LevelManager.winBingo) return true;

        if (block.xPos == block.yPos)
        {
            int left = 0;
            for (int i = 0; i < 5; i++)
            {
                if (myBooard.blockCheck[i, i].isSellect)
                {
                    left++;
                }
            }

            if (left >= LevelManager.winBingo) return true;
        }

        if (block.xPos + block.yPos == 4)
        {
            int x = 4;
            int right = 0;
            for (int i = 0; i < 5; i++)
            {
                if (myBooard.blockCheck[x, i].isSellect)
                {
                    right++;
                    x--;
                }
            }

            if (right >= LevelManager.winBingo) return true;
        }

        return false;

    }
}