using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverTime : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject feverButton;
    public GameObject feverPanel;
   public void Fever()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        feverButton.SetActive(true);
        feverPanel.SetActive(true);
        //피버타임 무지개 별 생성
    }
    public void FeverOff() //invoke로 딜레이 주기
    {
    
        feverButton.SetActive(false);
        feverPanel.SetActive(false);
        //피버타임 무지개 별 생성
    }
}
