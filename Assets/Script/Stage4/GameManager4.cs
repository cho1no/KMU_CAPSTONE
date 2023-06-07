using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 instance;

    public bool gameOver;
   private void Start()
    {
        instance = this;
    }
}
