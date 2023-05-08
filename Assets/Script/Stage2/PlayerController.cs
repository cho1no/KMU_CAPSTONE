using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Public")]
    public float jumpForce = 6f; // ���� ����
    public float gravity = -9.8f; // �߷� ���ӵ�
    Animator ani;
    public GameObject playerShadow;
    public GameObject HpItem;
    GameObject playershadow;

    [Header("Private")]
    private Rigidbody2D rb; // ���� ���� ����� ���� Rigidbody2D ������Ʈ
    private SpriteRenderer spriterenderer;
    [SerializeField] private bool ishit = false;
    [SerializeField] private int isGround = 0; // �ٴڿ� ��� �ִ��� üũ�ϴ� ����
    [SerializeField] private Vector3 FirstPosition;

    void Start()
    {
        FirstPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        ani = GetComponent<Animator>();
        playershadow = Instantiate(playerShadow, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Jump();
        }
        if (isGround == 2)
        {
            gameObject.tag = "Attack";
        }
        else
        {
            gameObject.tag = "Player";
        }
        // �߷� ����
        rb.velocity += new Vector2(0f, gravity * Time.deltaTime);

        MoveToFirstPosition();
        MoveShadow(playershadow);
    }
    public void Jump()
    {
        if (isGround < 2)
        {
            ani.SetBool("isJump", true);

            if (isGround < 1) 
                rb.velocity = new Vector2(0f, jumpForce);
            if (isGround == 1)
                rb.velocity = new Vector2(0f, jumpForce*0.7f);
            isGround += 1;
        }
        if (isGround == 2)
            ani.SetTrigger("isAttack");
    }
    void MoveToFirstPosition() //������ġ�� ������ġ�� �������ϱ�
    {
        if (transform.position.x != FirstPosition.x)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(FirstPosition.x, transform.position.y, transform.position.z), Time.deltaTime*5);
    }
    void MoveShadow(GameObject obj)
    {
        float Dist = Vector3.Distance(gameObject.transform.position, obj.transform.position);
        float scaleX = 0.7f - Dist;
        float scaleY = 0.15f - Dist / 5;
        if (scaleX <= 0.15f)
            scaleX = 0.15f;
        if (scaleY <= 0.03f)
            scaleY = 0.03f;
        obj.transform.position = new Vector3(transform.position.x, obj.transform.position.y, obj.transform.position.z);
        obj.transform.localScale = new Vector3(scaleX, scaleY, 0);
    }
    IEnumerator Invincibility()//����
    {
        int countTime = 0;
        while (countTime<=10)//0.2�ʸ��� countTime++ �� �����ð��� 0.2*10 = 2��
        {
            if (countTime % 2 == 0) spriterenderer.color = new Color32(255, 255, 255, 90);
            else spriterenderer.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriterenderer.color = new Color32(255, 255, 255, 255);
        ishit = false;
        yield return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        if (obj.tag == "Ground" || obj.tag =="Untagged")//���� Ƚ�� �ʱ�ȭ
        {
            isGround = 0;
            ani.SetBool("isJump", false);
        }
        if (obj.tag == "HpItem")
        {
            HpManager.instance.SetHp(1); 
            Destroy(obj);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (HpManager.instance.Hp != 0)
        {
            if (gameObject.tag == "Player" && !ishit)
            {
                if (obj.tag == "Obstacle1" || obj.tag == "Obstacle2")
                {
                    ani.SetTrigger("isHit");
                    HpManager.instance.SetHp(-1);
                    Debug.Log("hit");
                    //�¾��� �� ���ư���
                    Vector3 hitted = new Vector3(10, 10, 0);
                    rb.velocity = hitted;
                    ishit = true; //���� Ŵ
                    StartCoroutine("Invincibility");
                }
            }

            if (gameObject.tag == "Attack" && obj.tag == "Obstacle2")
            {
                Debug.Log("Crash");
                Destroy(obj);
                int random = 0; //UnityEngine.Random.Range(0, 10);
                if (random == 0)
                    Instantiate(HpItem, obj.transform.position, Quaternion.identity);
            }
        }
    }
}