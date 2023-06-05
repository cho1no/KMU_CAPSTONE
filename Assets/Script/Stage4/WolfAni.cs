using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.FantasyMonsters.Scripts;

public class WolfAni : MonoBehaviour
{
    Monster monster;
    [SerializeField]GameObject parent;
    private void Awake()
    {
        monster = GetComponent<Monster>();
        parent = transform.parent.gameObject;
    }
    private void OnEnable()
    {
        monster.SetHead(0);
    }
    private void Update()
    {
        if (parent.transform.GetChild(0).gameObject.activeSelf == false)
        {
            Dead();
        }
    }
    void Dead()
    {
        monster.Die();
    }
}
