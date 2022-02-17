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
    
    public void MuteData(int value)
    {
        PlayerPrefs.SetInt("MuteVolume", value);
    }

}
