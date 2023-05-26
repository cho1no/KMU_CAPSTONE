using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioOption : MonoBehaviour
{
    //private AudioSource audioSource;
    //private GameObject[] music;

    //private void Awake()
    //{
    //    music = GameObject.FindGameObjectsWithTag("Music");

    //    if(music.Length >= 2)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    DontDestroyOnLoad(transform.gameObject);
    //    audioSource = GetComponent<AudioSource>();
    //}
    //public void PlayMusic()
    //{
    //    if (audioSource.isPlaying) return;
    //    audioSource.Play();
    //}
    //public void StopMusic()
    //{
    //    audioSource.Stop();
    //}

    public AudioMixer mixer;
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
