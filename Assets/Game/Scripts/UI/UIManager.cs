using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIManager : SingleTon<UIManager>
    {
        public static WinGameUI winFinishGameUI;
        public static LoseGameUI loseFinishGameUI;
        
        public GameObject readyUI;


        public void OpenWinGameUI()
        {
            if (winFinishGameUI == null)
            {
                GameObject go = Resources.Load<GameObject>("UI/Canvas-WinGame");
                winFinishGameUI = Instantiate(go, transform).GetComponent<WinGameUI>();
            }
            else
            {
                winFinishGameUI.gameObject.SetActive(true);
            }
        }
        public void CloseWinGameUI()
        {
            winFinishGameUI.gameObject.SetActive(false);
        }

        public void OpenLoseGameUI()
        {
            if (loseFinishGameUI == null)
            {
                GameObject go = Resources.Load<GameObject>("UI/Canvas-LoseGame");
                loseFinishGameUI = Instantiate(go, transform).GetComponent<LoseGameUI>();
            }
            else
            {
                loseFinishGameUI.gameObject.SetActive(true);
            }
        }

        public void CloseLoseUI()
        {
            loseFinishGameUI.gameObject.SetActive(false);
        }

        public void ReadyGame()
        {
            GameManager.Instance.ChangGameState(GameState.Gameplay);
            readyUI.gameObject.SetActive(false);
        }
    }
}