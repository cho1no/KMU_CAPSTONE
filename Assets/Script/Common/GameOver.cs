using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public GameObject GameOverPanel;
    AudioSource audioSource;
    //Animator ani;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //ani = GetComponent<Animator>();
        instance = this;
    }
    public void gameOver()
    {
        //audioSource.Play();
        //DataManager.Instance.data.NowScore = Score.instance.scoreText;
        GameOverPanel.SetActive(true);
        //ani.SetTrigger("gameOver");
        Invoke("TimeStop", 1f);
    }
    private void TimeStop()
    {
        Time.timeScale = 0;
        audioSource.Stop();
    }
}
