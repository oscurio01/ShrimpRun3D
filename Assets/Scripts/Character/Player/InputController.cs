using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Switches
{
    public static bool enterDebugMode;
    public static bool debugMode;
}

public class InputController : MonoBehaviour
{
    KeyCode[] debugKey = { KeyCode.T, KeyCode.E };
    int debugKeyProgress = 0;

    [SerializeField] private float timeEnterTheKey;
    float timer;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            timer = timeEnterTheKey;
            Switches.enterDebugMode = true;
        }

        if (Switches.enterDebugMode)
        {
            if (!Switches.debugMode)
            {
                if (Input.GetKeyDown(debugKey[debugKeyProgress]))
                {
                    debugKeyProgress++;
                    if (debugKeyProgress == debugKey.Length)
                    {
                        Switches.debugMode = true;
                        debugKeyProgress = 0;
                        Debug.Log("Debug mode on");
                    }

                }
            }
            if (Switches.debugMode)
            {
                if (Input.GetKeyDown(debugKey[debugKeyProgress]))
                {
                    debugKeyProgress++;
                    if (debugKeyProgress == debugKey.Length)
                    {
                        Switches.debugMode = false;
                        debugKeyProgress = 0;
                        Debug.Log("Debug mode off");
                    }

                }
            }

            if(timer <= 0)
            {
                Switches.enterDebugMode = false;
                timer = timeEnterTheKey;
            }
            else
            {
                timer -= Time.deltaTime;
            }

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            UnityEditor.EditorApplication.isPaused = true;

            Application.Quit();
        }
    }
}
