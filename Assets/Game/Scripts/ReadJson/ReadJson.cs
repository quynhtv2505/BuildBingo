using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReadJson : SingleTon<ReadJson>
{
    public TextAsset textJson;
    public BotInfors Bots;
    [System.Serializable]
    public class BotConfigInfor
    {
        public int bingo0;
        public int bingo1;
        public int bingo2;
        public int bingo3;
        public int bingo4;
        public int bingo5;
    }

    [System.Serializable]
    public class BotInfors
    {
        public BotConfigInfor[] BotConfig;
    }

    private void Awake()
    {
        Bots = JsonUtility.FromJson<BotInfors>(textJson.text);
    }
    

    public int SellectBotConfig(int index, int number)
    {
        switch (number)
        {
            case 0:
                return Bots.BotConfig[index].bingo0;
            case 1:
                return Bots.BotConfig[index].bingo1;
            case 2:
                return Bots.BotConfig[index].bingo2;
            case 3:
                return Bots.BotConfig[index].bingo3;
            case 4:
                return Bots.BotConfig[index].bingo4;
            case 5:
                return Bots.BotConfig[index].bingo5;
        }
        return 0;
    }
}