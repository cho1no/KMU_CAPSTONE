using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadGameData();
        coinText.text = DataManager.Instance.data.point[0].ToString();
    }
    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
