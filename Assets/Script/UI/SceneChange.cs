using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void Stage1_Go()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2_Go()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3_Go()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void Stage5_Go()
    {
        SceneManager.LoadScene("Stage5");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
