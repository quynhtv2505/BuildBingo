using UnityEngine;
using TMPro;

public abstract class ABTarget : MonoBehaviour
{
    public TextMeshProUGUI textNumberTarget;

    private void Awake()
    {
        textNumberTarget = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        OnAwake();
    }


    public virtual void ViewNumber()
    {
    }

    public abstract void OnAwake();
}