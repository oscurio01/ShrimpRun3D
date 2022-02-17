using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    //public AudioSource[] Music;
    public AudioSource[] Effects;

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

    // Update is called once per frame
    void Update()
    {
        //MasterVolume();
        //EffectsVolume();
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

    public void PlayAudio(AudioSource audio)
    {
        if (!audio.isPlaying)
        {
            audio.Play();
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
