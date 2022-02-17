using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameOverIsON = false;
    bool onlyOnce = false;

    [SerializeField] GameObject gameOver;

    private void OnDisable()
    {
        gameOverIsON = false;
        onlyOnce = false;
    }
    public void ActiveGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        gameOverIsON = true;
    }

    public void ReplayLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        //gameOverText
    }
    private void Update()
    {
        if (gameOverIsON && onlyOnce == false)
        {
            ActiveGameOver();
            onlyOnce = true;
        }
    }
}
