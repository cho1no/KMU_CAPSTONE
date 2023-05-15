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
        //�ǹ�Ÿ�� ������ �� ����
    }
    public void FeverOff() //invoke�� ������ �ֱ�
    {
    
        feverButton.SetActive(false);
        feverPanel.SetActive(false);
        //�ǹ�Ÿ�� ������ �� ����
    }
}
