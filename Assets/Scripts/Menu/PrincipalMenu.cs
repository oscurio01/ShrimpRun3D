using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenu : MonoBehaviour
{

    public GameObject principalMenuUI;

    public GameObject selectLevelMenuUI;

    public GameObject howToPlayMenuUI;


    int level;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void SelectLevels()
    {
        selectLevelMenuUI.SetActive(true);
    }

    public void CloseSelectLevels()
    {
        selectLevelMenuUI.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlayMenuUI.SetActive(true);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void EnterLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void EnterLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void EnterLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
