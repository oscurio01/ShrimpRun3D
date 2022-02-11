using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    bool onlyOnce = false;
    private void Awake()
    {
        Time.timeScale = 0f;
        onlyOnce = false;
    }

    private void Update()
    {
        if (Input.anyKey && onlyOnce == false)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            onlyOnce = true;
        }
    }
}
