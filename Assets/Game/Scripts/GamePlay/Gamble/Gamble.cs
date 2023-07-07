using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamble : MonoBehaviour
{
    public TextMeshProUGUI textGamble;
    public int gamble;
    public Button bnts;
    public Image imageColor;
    public bool isSellect;
    public ParticleSystem fxGamble;

    private void Start()
    {
        textGamble.text = gamble.ToString();
        bnts = GetComponent<Button>();
        imageColor = GetComponent<Image>();
        bnts.onClick.AddListener(SellectGamble);
        isSellect = false;
    }

    public void SellectGamble()
    {
        if (!isSellect)
        {
            if (BaseGamble.Instance.myGamble != null)
            {
                BaseGamble.Instance.myGamble.isSellect = false;
                BaseGamble.Instance.myGamble.imageColor.color = Color.white;
            }

            BaseGamble.Instance.myGamble = this;
            BaseGamble.Instance.myGamble.imageColor.color = Color.green;
            BaseGamble.Instance.myGamble.fxGamble.Play();
            BaseGamble.Instance.myGamble.isSellect = true;
            LevelManager.Instance.willGamble = true;
        }
        else
        {
            BaseGamble.Instance.myGamble.isSellect = false;
            BaseGamble.Instance.myGamble.imageColor.color = Color.white;
            LevelManager.Instance.willGamble = false;
        }

        SoundManager.Instance.sfxBnts.Play();
        LevelManager.Instance.gamBle = gamble;
    }
}