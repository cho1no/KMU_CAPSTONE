using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager5 : MonoBehaviour
{
    public static GameManager5 instance;

    public poolManager pool;
    public PlayerControl player;
    public Weapon weapon;

    private void Awake()
    {
        instance = this;
    }
}
