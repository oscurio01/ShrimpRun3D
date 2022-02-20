using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausedMenuUI;

    public void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Quit()
    {
        Resume();
        SceneManager.LoadScene("Menu");
        Screen.SetResolution(PlayerPrefs.GetInt("resolutionWidth"), PlayerPrefs.GetInt("resolutionHeight"), Screen.fullScreen);
        //Application.Quit();
    }

    public void Paused()
    {
        if(!GameIsPaused && !GameOverMenu.gameOverIsON && !TriggerGoal.StageComplete)
        {
            pausedMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void OpenSettings()
    {
        pausedMenuUI.SetActive(false);
    }

    public void CloseSettings()
    {
        pausedMenuUI.SetActive(true);

    }

}
