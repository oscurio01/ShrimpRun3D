using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    public static bool begin = false;
    bool onlyOnce = false;
    private void Awake()
    {
        Time.timeScale = 0f;
        begin = false;
        onlyOnce = false;
    }

    private void Update()
    {
        if (Input.anyKey && onlyOnce == false)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            onlyOnce = true;
            begin = true;
        }
    }
}
