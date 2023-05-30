using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Start()
    {
        DataManager.Instance.LoadGameData();
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void FistToLobby()
    {
        IEnumerator FTL()
        {
            yield return new WaitForSeconds(0.6f);
            SceneManager.LoadScene("LobbyScene");
        }
        StartCoroutine(FTL());
    }
    public void LobbyScene()
    {
        Time.timeScale = 1.0f;
        DataManager.Instance.data.SceneState = 0;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("LobbyScene");
    }
    public void Stage1_Go()
    {
        DataManager.Instance.data.SceneState = 1;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2_Go()
    {
        DataManager.Instance.data.SceneState = 2;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3_Go()
    {
        DataManager.Instance.data.SceneState = 3;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("Stage3");
    }

    public void Stage5_Go()
    {
        DataManager.Instance.data.SceneState = 5;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("Stage5");
    }
    public void Restart()
    {
        switch (DataManager.Instance.data.SceneState)
        {
            case 0:
                SceneManager.LoadScene("LobbyScene");
                break;
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            //case 4:
            //    break;
            case 5:
                SceneManager.LoadScene("Stage5");
                break;
        }
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        int nowscore = int.Parse(Score.instance.scoreText.text);
        PlayerPrefs.SetInt("NowScore", nowscore);
        SceneManager.LoadScene("GameOver");
    }
}
