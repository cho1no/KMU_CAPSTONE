using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreLoad : MonoBehaviour
{
    public Text NowScore;
    public Text BestScore;
    // Start is called before the first frame update
    void Start()
    {
        int i = DataManager.Instance.data.SceneState;
        LoadScore(i);            
    }
    void LoadScore(int num)
    {
        NowScore.text = PlayerPrefs.GetInt("NowScore").ToString();
        if (PlayerPrefs.GetInt("NowScore") > DataManager.Instance.data.highScore[num - 1])
            DataManager.Instance.data.highScore[num - 1] = PlayerPrefs.GetInt("NowScore");
        BestScore.text = DataManager.Instance.data.highScore[num-1].ToString();
        GetCoin(num);
        DataManager.Instance.SaveGameData();
    }
    void GetCoin(int num)
    {
        int GetStar = 0;
        switch (num)
        {
            case 1:
                GetStar = int.Parse(NowScore.text) / 5;
                break;
            case 2:
                GetStar = int.Parse(NowScore.text) / 5;
                break;
            case 3:
                GetStar = int.Parse(NowScore.text) / 5;
                break;
            case 4:
                GetStar = int.Parse(NowScore.text) / 5;
                break;
            case 5:
                GetStar = int.Parse(NowScore.text) / 5;
                break;
        }
        DataManager.Instance.data.coin += GetStar;
        PlayerPrefs.DeleteAll();
    }
}
