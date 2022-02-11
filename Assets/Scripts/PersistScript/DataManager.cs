using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    //public Vector2 lastCheckPoint;
    public string StringActiveBetweenScenes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void MusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }    

    public void SfxData(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
    public void CurrentHealth(int value)
    {
        PlayerPrefs.SetInt("heartsAmount", value);
    }    
    public void MaxHealth(int value)
    {
        PlayerPrefs.SetInt("maxHealth", value);
    }

    public void Resolution(int reWidth, int reHeight)
    {
        PlayerPrefs.SetInt("resolutionWidth", reWidth);
        PlayerPrefs.SetInt("resolutionHeight", reHeight);

    }
    public void Screenfull(bool fullScreen)
    {
        PlayerPrefs.SetInt("isFullScreen", fullScreen ? 1 : 0);
    }
}
