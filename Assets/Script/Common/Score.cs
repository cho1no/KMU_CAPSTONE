using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;

    int score1;

    private void Awake()
    {
        instance = this;
    }
    public void GetScore(int score)
    {
        this.score1 += score;
        scoreText.text = score1.ToString();
    }
}
