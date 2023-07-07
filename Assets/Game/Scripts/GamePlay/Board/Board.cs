using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
namespace Game.Scripts.GamePlay.Board
{
    public class Board : MonoBehaviour
    {
        static private int heigh = 5;
        static private int with = 5;
        public GameObject content;
        public LineEndBingo lineEndBingoPrefab;
        public FadeTurnCooldow imageTurn;
        public Block blockPrefab;
        public List<Block> listBlocks = new List<Block>();
        public Character myCharacter;
        public Block[,] blockCheck = new Block[with, heigh];
        private List<int> listCounts = new List<int>();

        private void Awake()
        {
            for (int i = 1; i < LevelManager.Instance.countBingo + 1; i++)
            {
                listCounts.Add(i);
            }
        }

        public void OnInit(Character cha)
        {
            myCharacter = cha;
            int count = LevelManager.Instance.countBingo;
            for (int i = 0; i < count; i++)
            {
                Block block = Instantiate(blockPrefab, content.transform);
                int index = Random.Range(0, listCounts.Count);
                block.InitNumber(listCounts[index], i, this);
                listCounts.RemoveAt(index);
                listBlocks.Add(block);
            }
            AddElementInArray();
        }

        private void AddElementInArray()
        {
            int number = 0;
            for (int i = 0; i < heigh; i++)
            {
                for (int j = 0; j < with; j++)
                {
                    listBlocks[number].xPos = j;
                    listBlocks[number].yPos = i;
                    blockCheck[j, i] = listBlocks[number];
                    blockCheck[j, i].CheckWeigh();
                    number++;
                }
            }
        }

        public void CheckBlock()
        {
            int count = CheckRow() + CheckCollum() + CheckLeft() + CheckRight();
            if (count >= LevelManager.winBingo)
            {
                LevelManager.Instance.FinishGame(myCharacter);
            }
        }

        private int CheckRow()
        {
            int index = 0;
            for (int i = 0; i < with; i++)
            {
                int count = 0;
                for (int j = 0; j < heigh; j++)
                {
                    if (blockCheck[j, i].isSellect)
                    {
                        count++;
                    }
                }

                if (count >= LevelManager.winBingo)
                {
                    index++;
                    SetLineBlock(blockCheck[0, i].transform.position, blockCheck[4, i].transform.position);
                }
            }

            return index;
        }

        private int CheckCollum()
        {
            int index = 0;
            for (int i = 0; i < with; i++)
            {
                int count = 0;
                for (int j = 0; j < heigh; j++)
                {
                    if (blockCheck[i, j].isSellect)
                    {
                        count++;
                    }
                }

                if (count >= LevelManager.winBingo)
                {
                    index++;
                    SetLineBlock(blockCheck[i, 0].transform.position, blockCheck[i, 4].transform.position);
                }
            }

            return index;
        }

        private int CheckLeft()
        {
            int index = 0;
            for (int i = 0; i < with; i++)
            {
                if (blockCheck[i, i].isSellect)
                {
                    index++;
                }
            }
            if (index >= LevelManager.winBingo)
            {
                SetLineBlock(blockCheck[0,0].transform.position,blockCheck[4,4].transform.position);
                return 1;
            }
            return 0;
        }

        private int CheckRight()
        {
            int index = 0;
            for (int i = 0; i < with; i++)
            {
                for (int j = 4; j >= 0; j--)
                {
                    if (blockCheck[i, j].isSellect && i + j == 4)
                    {
                        index++;
                    }
                }
            }

            if (index >= LevelManager.winBingo)
            {
                SetLineBlock(blockCheck[0, 4].transform.position, blockCheck[4, 0].transform.position);
                return 1;
            }

            return 0;
        }

        private void SetLineBlock(Vector3 current, Vector3 target)
        {
            LineEndBingo lineEnd = Instantiate(lineEndBingoPrefab, transform);
            lineEnd.SetPos(current, target);
            //SoundManager.Instance.sfxLineBingo.Play();

        }
    }
}