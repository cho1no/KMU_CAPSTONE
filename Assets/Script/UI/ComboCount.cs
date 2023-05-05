using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboCount : MonoBehaviour
{
    public ComboText combotext;
    public TextMeshProUGUI comboText1;
    Animator myAnim;
    string aniCombo = "Combo";
    private void Start()
    {
        myAnim = GetComponent<Animator>();
        comboText1 = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        ChangeColor();
    }
    public void ChangeColor()
    {
        if (combotext.combo >= 50 && combotext.combo <= 99)
        {
            comboText1.color = Color.yellow;
        }
        else if (combotext.combo >= 100 && combotext.combo <= 149)
        {
            comboText1.color = Color.red;
        }
        else if (combotext.combo >= 150 && combotext.combo <= 199)
        {
            comboText1.color = Color.magenta;
        }
        else if (combotext.combo >= 200 && combotext.combo <= 249)
        {
            comboText1.color = Color.blue;
        }
        else if (combotext.combo >= 250 && combotext.combo <= 299)
        {
            comboText1.color = Color.cyan;
        }
        else if (combotext.combo >= 300 && combotext.combo <= 349)
        {
            comboText1.color = Color.green;
        }
    }
    public void Ani()
    {
        myAnim.SetTrigger(aniCombo);
    }
}

