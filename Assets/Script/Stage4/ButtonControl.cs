using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button leftButton, rightButton, hitButton;
    float speed = 1.5f;
    [SerializeField] GameObject target =null;

    public List<GameObject> balloonList1 = new List<GameObject>(); //왼쪽자리
    public List<GameObject> balloonList2 = new List<GameObject>(); //중앙자리
    public List<GameObject> balloonList3 = new List<GameObject>(); //오른쪽자리

    [SerializeField] bool section1, section2, section3;
    private void Awake()
    {
    }
    private void Start()
    {
        leftButton.onClick.AddListener(LeftButton);
        hitButton.onClick.AddListener(HitButton);
        rightButton.onClick.AddListener(RightButton);
     
        
    }
    private void Update()
    {
        Section();
        TargetHit();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f), -2, 0);
    }
    public void LeftButton()
    {
        transform.position = new Vector3(transform.position.x - speed, -2, 0);
    }
    public void HitButton()
    {
        target.transform.localScale += new Vector3(0.1f,0.1f, 0); //만큼 증가
    }
    public void RightButton()
    {
        transform.position = new Vector3(transform.position.x + speed, -2, 0);
    }

    void Section()
    {
        if (transform.position.x == -1.5f)
        {
            section1 = true;
            section2 = false;
            section3 = false;
        }
        else if (transform.position.x == 0)
        {
            section1 = false;
            section2 = true;
            section3 = false;
        }
        else if (transform.position.x == 1.5f)
        {
            section1 = false;
            section2 = false;
            section3 = true;
        }
    }
    void TargetHit()
    {

        if (section1)
        {
            if (balloonList1.Count >= 1)
                target = balloonList1[0];
            if (balloonList1.Count < 1)
                target = null;
        }
        if (section2)
        {
            if (balloonList2.Count >= 1)
                target = balloonList2[0];
            if (balloonList2.Count <1)
                target = null;
        }
        if (section3)
        {
            if (balloonList3.Count >= 1)
                target = balloonList3[0];
            if (balloonList3.Count < 1)
                target = null;
        }
        //if (section2 && balloonList2.Count >= 1)
        //{
        //    target = balloonList2[0];  
        //}
        //if (section3 && balloonList3.Count >= 1)
        //{
        //    target = balloonList3[0];  
        //}

        //if (section3 && balloonList3.Count < 1)
        //{
        //    target = null;
        //}
        //if (section2 && balloonList2.Count < 1)
        //{
        //    target = null;
        //}
        //if (section1 && balloonList1.Count < 1)
        //{
        //    target = null;
        //}

        //if (section2 && balloonList2.Count >= 1)
        //{
        //    target = balloonList2[0];
        //}
        //if (section3 && balloonList3.Count >= 1)
        //{
        //    target = balloonList3[0];
        //}
    }
}
