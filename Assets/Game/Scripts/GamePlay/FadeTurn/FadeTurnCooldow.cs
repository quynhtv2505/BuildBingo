using UnityEngine;
using UnityEngine.UI;

public class FadeTurnCooldow : MonoBehaviour
{
    public Image imageTurn;
    private float timerDown;
    private float timeValue;

    public void StartCooldow()
    {
        timeValue = 5f;
        timerDown = timeValue;
        imageTurn.fillAmount = 0f;
    }
    public void UpdateCooldow()
    {
        if (timerDown >= 0f)
        {
            timerDown -= Time.deltaTime;
            imageTurn.fillAmount = timerDown / timeValue;
        }
    }
}