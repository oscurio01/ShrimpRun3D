using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject returnButton;

    public void OpenReturnButton()
    {
        returnButton.SetActive(true);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
