using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonControl : MonoBehaviour
{
    float speed = 0.6f;
    ButtonControl buttonControl;
    private void Awake()
    {
        buttonControl = FindObjectOfType<ButtonControl>();
    }
    private void OnEnable()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }
    private void Update()
    {
        if (transform.localScale == new Vector3(1.5f, 1.5f, 1))
        {
            gameObject.SetActive(false);
            ListRemove();
        }
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
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
