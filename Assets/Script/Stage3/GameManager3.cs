using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;

    public poolManager pool;
    public PlayerRotation player;

    private void Awake()
    {
        instance = this;
    }
}
