using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public Button bnts;

    private void Start()
    {
        bnts = GetComponent<Button>();
        bnts.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        if (GameManager.Instance.IsGameState(GameState.MainMenu) && LevelManager.Instance.willGamble)
        {
            SoundManager.Instance.sfxBnts.Play();
            SceneManager.activeSceneChanged += LevelManager.Instance.OnGameSceneChanged;
            SceneManager.LoadScene(2);
        }
    }
}