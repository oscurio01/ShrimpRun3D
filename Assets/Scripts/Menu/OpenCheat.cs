using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheat : MonoBehaviour
{
    public static event Action<int> IncreaseShrimpsEvent = delegate { };
    public static event Action DecreaseShrimpsEvent = delegate { };

    [SerializeField] GameObject cheatButton;
    [SerializeField] GameObject cheatList;

    private bool OnlyOnce = false;

    private void Awake()
    {
        cheatButton.SetActive(false);
    }

    
    void Update()
    {
        if (Switches.debugMode && Switches.enterDebugMode)
        {
            cheatButton.SetActive(true);
            OnlyOnce = true;
        }
        else if(OnlyOnce == true)
        {
            OnlyOnce = false;

            Time.timeScale = 1f;
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
                Time.timeScale = 1f;
            }
            else
            {
                cheatList.SetActive(true);
                Time.timeScale = 0.7f;
            }
        }

    }

    public void InmortalPlayer()
    {
        if(PlayerController.inmortal == false)
        {
            PlayerController.inmortal = true;
            Debug.Log("Player is inmortal");
        }
        else
        {
            PlayerController.inmortal = false;
            Debug.Log("Player is not inmortal");
        }
    }

    public void DecreaseShrimps()
    {
        DecreaseShrimpsEvent();
    }

    public void IncreaseShrimps()
    {
        IncreaseShrimpsEvent(1);
    }

}
