using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[Serializable]
public class AudioOrigin
{
    public string Name;
    public AudioSource audio;
}

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    [SerializeField]
    private List<AudioOrigin> audioList = new List<AudioOrigin>();

    public static AudioManager instance;

    public float masterVol, effectsVol;
    public Slider masterSldr, effectsSldr;
    public Toggle Mute;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //masterSldr.value = masterVol;
        //effectsSldr.value = effectsVol;

        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;

        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;

        masterSldr.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        effectsSldr.value = PlayerPrefs.GetFloat("SFXVolume", 0f);

        Mute.isOn = PlayerPrefs.GetInt("MuteVolume", 0) == 0 ? false : true;

    }

    public void MasterVolume()
    {
        DataManager.instance.MusicData(masterSldr.value);
        musicMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }    
    
    public void EffectsVolume()
    {
        DataManager.instance.SfxData(effectsSldr.value);
        effectsMixer.SetFloat("effectsVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }

    public void PlayAudioSelected(string name)
    {
        for (int i = 0; i < audioList.Count; i++)
        {
            if(audioList[i].Name == name && !audioList[i].audio.isPlaying)
            {
                audioList[i].audio.Play();
            }
        }

    }
    
    public void MuteVolume()
    {
        DataManager.instance.MuteData(Mute.isOn? 1:0);

        if (Mute.isOn)
        {
            musicMixer.SetFloat("masterVolume", -80);
            effectsMixer.SetFloat("effectsVolume", -80);
        }
        else
        {
            musicMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MusicVolume"));
            effectsMixer.SetFloat("effectsVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }

    }
}
