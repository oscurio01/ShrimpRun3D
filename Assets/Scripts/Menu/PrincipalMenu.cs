using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenu : MonoBehaviour
{

    public GameObject principalMenuUI;

    int level;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void SelecLevels()
    {
        SceneManager.LoadScene("IntroduceCinematic");


        //DeleteAllInfoFromPlayer();
    }

    public void LoadGame()
    {
        int levelState = 1; //DBManager.GetLevelState();
        if (levelState != -1)
        {
            DataManager.instance.StringActiveBetweenScenes = "LoadGame";
            level = levelState;
            SceneManager.LoadScene(level);
        }
        
        
        //SceneManager.LoadScene("Game1");
        // The game will start, at the level where you left off

    }    

    public void OpcionMenu()
    {
        principalMenuUI.SetActive(false);
        //OpcionsMenuUI.SetActive(true);

        SceneManager.LoadScene("Menu");
        //Application.Quit();
    }    
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
