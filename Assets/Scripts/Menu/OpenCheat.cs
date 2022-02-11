using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheat : MonoBehaviour
{
    [SerializeField] GameObject cheatButton;
    [SerializeField] GameObject cheatList;

    private void Awake()
    {
        cheatButton.SetActive(false);
    }

    
    void Update()
    {
        if (Switches.debugMode && Switches.enterDebugMode)
        {
            cheatButton.SetActive(true);
        }
        else
        {
            cheatButton.SetActive(false);
            cheatList.SetActive(false);
        }
    }

    public void OpenListCheat()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (cheatList.activeInHierarchy)
            {
                cheatList.SetActive(false);
            }
            else
            {
                cheatList.SetActive(true);
            }
        }

    }
}
