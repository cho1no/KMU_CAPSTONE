using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExplan : MonoBehaviour
{
    public GameObject ExpPanel;
    // Start is called before the first frame update
    void Start()
    {
        ExpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGame()
    {
        Time.timeScale = 1;
        ExpPanel.SetActive(false);
    }
}
