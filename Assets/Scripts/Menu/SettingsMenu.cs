using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenuUI;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private void Awake()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("resolutionWidth"), PlayerPrefs.GetInt("resolutionHeight"), Screen.fullScreen);
        Debug.Log("a3 " + PlayerPrefs.GetInt("resolutionWidth") + " s " + Screen.width + " / " + PlayerPrefs.GetInt("resolutionHeight") + " s " + Screen.height);

    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }

        // Only accept and string
        resolutionDropdown.AddOptions(options);
        // To put our resolution first
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void OpenSettings()
    {
        SettingsMenuUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsMenuUI.SetActive(false);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        DataManager.instance.Screenfull(isFullscreen);

        if (PlayerPrefs.GetInt("isFullScreen") == 1)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        DataManager.instance.Resolution(resolution.width, resolution.height);

        int width = PlayerPrefs.GetInt("resolutionWidth");
        int height = PlayerPrefs.GetInt("resolutionHeight");
        bool fullScreen = PlayerPrefs.GetInt("isFullScreen") == 1 ? true : false ;

        Screen.SetResolution(width, height, fullScreen);
    }
}
