using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadControl : MonoBehaviour
{
    [SerializeField]float speed = 0.6f;
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        speed = 0.6f;
        transform.GetChild(0).gameObject.SetActive(true);
        ani.SetBool("Dead", false);
    }
    private void Update()
    {
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        BalloonOff();
        ObjectFalse();
    }
    void BalloonOff()
    {
        if (transform.GetChild(0).gameObject.activeSelf == false)// 터졌을때
        {
            ani.SetBool("Dead", true);
            speed = -3;
        }
    }
    void ObjectFalse()
    {
        if (transform.position.y <= -6)
        {
            gameObject.SetActive(false);
        }
    }
}
