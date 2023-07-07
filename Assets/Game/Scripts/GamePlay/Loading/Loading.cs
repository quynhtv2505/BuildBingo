using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private float timer;

    private void Start()
    {
        timer = 0;
        SceneManager.activeSceneChanged += ChangScene;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            Chang();
        }
    }

    public void Chang()
    {
        GameManager.Instance.ChangGameState(GameState.MainMenu);
        SceneManager.LoadScene(1);
    }

    public void ChangScene(Scene s1, Scene s2)
    {
        SceneManager.activeSceneChanged -= ChangScene;
        //SceneManager.activeSceneChanged += LevelManager.Instance.OnGameSceneChanged;
    }
}