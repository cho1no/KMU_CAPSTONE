using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    public void sideattack()
    {
        ani.SetTrigger("doside");
    }
    public void upattack()
    {
        ani.SetTrigger("doup");
    }
    public void hitmotion()
    {
        ani.SetTrigger("dohit");
    }
}
