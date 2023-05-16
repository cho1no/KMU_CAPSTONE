using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboText : MonoBehaviour
{
    public int combo;
    TextMeshProUGUI comboText;
    Animator myAnim;
    string aniCombo = "Combo";


    private void Start()
    {
        myAnim = GetComponent<Animator>();
        comboText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Combo());

    }
    private void Update()
    {
        ChangeColor();
    }
    public IEnumerator Combo()
    {
        while (true)
        {
            comboText.text = string.Format("{0:#,##0}", combo);
            yield return new WaitForSeconds(.2f);
            comboText.text = "";
        }
    }
    public void ChangeColor()
    {
        if (combo >= 50 && combo <= 99)
        {
            comboText.color = Color.yellow;
        }
        else if (combo >= 100 && combo <= 149)
        {
            comboText.color = Color.red;
        }
        else if (combo >= 150 && combo <= 199)
        {
            comboText.color = Color.magenta;
        }
        else if (combo >= 200 && combo <= 249)
        {
            comboText.color = Color.blue;
        }
        else if (combo >= 250 && combo <= 299)
        {
            comboText.color = Color.cyan;
        }
        else if (combo >= 300 && combo <= 349)
        {
            comboText.color = Color.green;
        }
    }
    public void Ani()
    {
        myAnim.SetTrigger(aniCombo);
    }
    public int GetCombo()
    {
        return combo;
    }
    public void IncreaseCombo(int newCombo = 1 )
    {
        combo += newCombo;
        comboText.text = string.Format("{0:#,##0}", combo);
    }

}