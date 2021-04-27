using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VolumeControl : MonoBehaviour
{
    private static readonly string firstPlay = ("FirstPlay");
    private static readonly string SFXPref = ("SFXVolume");
    public AudioSource[] SFXAudioSrc;
    public Slider SFXSlider;
    private float SFXVolume;
    private int FirstTimePlayInt;
    private void Start()
    {

        FirstTimePlayInt = PlayerPrefs.GetInt(firstPlay);
        if (FirstTimePlayInt == 0)
        {
            SFXVolume = 0.2f;
            SFXSlider.value = SFXVolume;
            PlayerPrefs.SetFloat(SFXPref, SFXVolume);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {

            SFXVolume = PlayerPrefs.GetFloat(SFXPref);
            SFXSlider.value = SFXVolume;
        }
    }
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(SFXPref, SFXSlider.value);
    }
    void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus)
        {
            SaveSoundSetting();
        }
    }
    public void updateSound()
    {
        for (int i = 0; i < SFXAudioSrc.Length; i++)
        {
            SFXAudioSrc[i].volume = SFXSlider.value;
        }
    }

}




// private void Awake()
// {
//     DontDestroyOnLoad(this.gameObject);
// }
// private void Start()
// {
//     BGMAudioSrc.Play();

//     BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
//     BGMAudioSrc.volume = BGMVolume;
//     BGMSlider.value = BGMVolume;

//     SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
//     SFXAudioSrc.volume = SFXVolume;
//     SFXSlider.value = SFXVolume;

// }

// void Update()
// {

//     BGMAudioSrc.volume = BGMVolume;
//     PlayerPrefs.SetFloat("BGMVolume", BGMVolume);
//     SFXAudioSrc.volume = SFXVolume;
//     PlayerPrefs.SetFloat("SFXVolume", BGMVolume);
// }

// public void SetBGMVolume(float BGMVol)
// {
//     BGMVolume = BGMVol;
// }
// public void SetSFXVolume(float SFXVol)
// {
//     SFXVolume = SFXVol;
// }