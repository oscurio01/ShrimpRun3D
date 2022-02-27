using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlayMenuUI;
    public GameObject nextPage;
    public GameObject previousPage;

    public void OpenMenu()
    {
        howToPlayMenuUI.SetActive(true);
        previousPage.SetActive(true);
    }

    public void CloseMenu()
    {
        howToPlayMenuUI.SetActive(false);

    }

    public void NextPage()
    {
        nextPage.SetActive(true);
        previousPage.SetActive(false);
    }

    public void PreviousPage()
    {
        previousPage.SetActive(true);
        nextPage.SetActive(false);
    }
}
