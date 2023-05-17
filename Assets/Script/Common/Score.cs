using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;

    int score1;
    public Animator ani;
    TimingManager timing;
    string aniScoreUp = "ScoreUp";


    private void Awake()
    {
        timing = FindObjectOfType<TimingManager>();
        instance = this;
    }
    public void GetScore(int score)
    {
        this.score1 += score;
        scoreText.text = score1.ToString();
        ani.SetTrigger(aniScoreUp);
    }
    public void GetScore(int score, int combo)
    {
        timing.IncreaseCombo(combo);
        this.score1 += score;
        scoreText.text = score1.ToString();
        ani.SetTrigger(aniScoreUp);
    }
}
