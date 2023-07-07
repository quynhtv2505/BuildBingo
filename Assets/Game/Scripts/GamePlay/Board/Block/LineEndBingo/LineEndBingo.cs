using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEndBingo : MonoBehaviour
{
    public LineRenderer lineRender;
    void Start()
    {
        lineRender.positionCount = 2;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameState(GameState.FinishGame))
        {
            Invoke(nameof(OffRender),1f);
        }
    }

    public void SetPos(Vector3 start,Vector3 end)
    {
        lineRender.SetPosition(0,start);
        lineRender.SetPosition(1,end);
    }

    public void OffRender()
    {
        Destroy(gameObject); 
    }
}
