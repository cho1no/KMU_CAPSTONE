using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider[] slider;

    void Start()
    {
        slider[0].value = PlayerPrefs.GetFloat("MusicVolume");
        slider[1].value = PlayerPrefs.GetFloat("EffectVolume");
        mixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        mixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume")) * 20);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    public void SetLevel1(float sliderValue)
    {
        mixer.SetFloat("EffectVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
}
