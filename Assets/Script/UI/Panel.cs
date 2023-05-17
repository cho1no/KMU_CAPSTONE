using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Animator ani;
    //public GameObject TotalPanel;
    public GameObject[] Stage;
    public GameObject[] PanelList;

    public GameObject gameOver;
    public GameObject unlock;
    public GameObject needCoin;
    public GameObject buystage;
    public GameObject lockStage2;

    public GameObject lockStage3;

    public bool TotalGameState = false;
    private void Start()
    {
        //Debug.Log("false");
    }
    private void Update()
    {
        ani.SetBool("Started", TotalGameState);
    }
    public void goMain()
    {
        ani.SetTrigger("GoMain");
    }
    public void GamePanelOn()
    {
        for (int i = 0; i < PanelList.Length; i++) {
            PanelList[i].SetActive(false);
            PanelList[0].SetActive(true);
        }
    }
    public void OptionPanelOn()
    {
        for (int i = 0; i < PanelList.Length; i++)
        {
            PanelList[i].SetActive(false);
            PanelList[1].SetActive(true);
        }
    }
    public void CharPanelOn()
    {
        for (int i = 0; i < PanelList.Length; i++)
        {
            PanelList[i].SetActive(false);
            PanelList[2].SetActive(true);
        }
    }
    public void BuyPanelOn()
    {
        for (int i = 0; i < PanelList.Length; i++)
        {
            PanelList[i].SetActive(false);
            PanelList[3].SetActive(true);
        }
    }
    public void panelUp()
    {
        //TotalGameState = true;
        //TotalPanel.SetActive(true); 
        ani.SetTrigger("PanelUp");
    }
    public void panelDown()
    {
        //TotalPanel.SetActive(false);
        ani.SetTrigger("PanelDown");
    }

    public void Stage1()
    {
        for (int i = 0; i < Stage.Length; i++) {
            Stage[i].SetActive(false);
            
        }
        Stage[0].SetActive(true);
    }
    public void Stage2()
    {
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i].SetActive(false);
            
        }
        Stage[1].SetActive(true);
    }
    public void Stage3()
    {
        //Stage[0].SetActive(true);
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i].SetActive(false);
            
        }
        Stage[2].SetActive(true);
    }
    public void Stage4()
    {
        //Stage[0].SetActive(true);
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i].SetActive(false);
            
        }
        Stage[3].SetActive(true);
    }
    public void Stage5()
    {
        //Stage[0].SetActive(true);
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i].SetActive(false);
            
        }
        Stage[4].SetActive(true);
    }
    public void Stage6()
    {
        //Stage[0].SetActive(true);
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i].SetActive(false);
            
        }
        Stage[5].SetActive(true);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void UnlockPanel()
    {
        //if (coin.coin >= 1)
        //{
        //    unlock.SetActive(true);
        //}
        //else { needCoinPanel(); }
    }
    public void UnlockPanelOff()
    {
        unlock.SetActive(false);
    }
    public void needCoinPanel()
    {
        needCoin.SetActive(true);
    }
    public void needCoinPanelOff()
    {
        needCoin.SetActive(false);
    }
    public void BuyStage()
    {
        buystage.SetActive(true);

    }
    public void BuyStageOff()
    {
        buystage.SetActive(false);
    }
    public void BuyStage3()
    {
        //BuyStageOff();
        //lockStage3.SetActive(false);
        //stage3.SetActive(true);
        //coin.coin -= 1;
    }
}
