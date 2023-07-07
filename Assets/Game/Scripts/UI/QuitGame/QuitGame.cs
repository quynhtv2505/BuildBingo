using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button bntsQuit;

    private void Start()
    {
        bntsQuit.onClick.AddListener(ExitGame);
    }

    protected void ExitGame()
    {
        Application.Quit();
    }
}