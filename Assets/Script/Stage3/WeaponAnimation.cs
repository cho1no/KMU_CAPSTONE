using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public PlayerRotation playerRotaition;
    Animator ani;
    SpriteRenderer spriter;
    void Awake()
    {
        ani = gameObject.GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }
    public void WeaponRotation()
    {
        if (playerRotaition.speed != 0)
        {
            spriter.flipX = playerRotaition.speed < 0;
        }
           
    }
    public void sideattack()
    {
        ani.SetTrigger("doside");
    }
    public void upattack()
    {
        ani.SetTrigger("doup");
    }
}
