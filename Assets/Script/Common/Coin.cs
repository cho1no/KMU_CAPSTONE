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
    int compareCoin;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadGameData();
        coinText.text = DataManager.Instance.data.coin.ToString();
        compareCoin = DataManager.Instance.data.coin;
    }
    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }
    // Update is called once per frame
    void Update()
    {
        if (compareCoin != DataManager.Instance.data.coin)
        {
            coinText.text = DataManager.Instance.data.coin.ToString();
            compareCoin = DataManager.Instance.data.coin;
        }
    }
}
