using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject SettingsMenuUI;

    public void OpenSettings()
    {
        SettingsMenuUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsMenuUI.SetActive(false);

    }

}
