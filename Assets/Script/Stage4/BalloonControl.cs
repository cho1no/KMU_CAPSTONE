using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonControl : MonoBehaviour
{
    //float speed = 0.6f;
    ButtonControl buttonControl;
    //Transform balloon;
    //Animator ani;
    private void Awake()
    {
        buttonControl = FindObjectOfType<ButtonControl>();
        //balloon = transform.parent;
        //ani = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
    }
    private void Update()
    {
        if (transform.localScale == new Vector3(0.35f, 0.35f, 1))
        {
            Score.instance.GetScore(30);
            gameObject.SetActive(false);
            ListRemove();
            //ani.SetBool("Bomb", true);
        }
        if (transform.position.y >= 5)
        {
            gameObject.SetActive(false);
            ListRemove();
            GameManager4.instance.gameOver = true;
        }

    }
    void ListRemove()
    {
        if (gameObject.tag == "Section1")
        {
            buttonControl.balloonList1.RemoveAt(0);
        }
        else if (gameObject.tag == "Section2")
        {
            buttonControl.balloonList2.RemoveAt(0);
        }
        else if (gameObject.tag == "Section3")
        {
            buttonControl.balloonList3.RemoveAt(0);
        }
    }
}
