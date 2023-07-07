using UnityEngine;
using TMPro;

public class CointManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        LevelManager.Instance.cointGame = this;
        coinText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        coinText.text = LevelManager.Instance.coint.ToString();
    }
}