using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioOption : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private GameObject[] music;
    private void Awake()
    {
        music = GameObject.FindGameObjectsWithTag("Music");

        if (music.Length >= 2)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

}
