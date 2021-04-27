using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlInGame : MonoBehaviour
{
    public Slider SFXSlider;
    private float SFXVolume;

    public AudioSource[] SFXAudioSrc;
    void Start()
    {
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = SFXVolume;
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
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
