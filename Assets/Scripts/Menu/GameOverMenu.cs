using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameOverIsON = false;
    bool show = false;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameOverText;

    private void OnDisable()
    {
        gameOverIsON = false;
    }
    public void ActiveGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        gameOverIsON = true;
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {
        //gameOverText
    }
    private void Update()
    {
        if (show)
        {
            
        }
    }
}
