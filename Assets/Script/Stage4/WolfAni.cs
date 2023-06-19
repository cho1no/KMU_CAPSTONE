using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.FantasyMonsters.Scripts;

public class WolfAni : MonoBehaviour
{
    int speed = 2;
    Monster monster;
    Rigidbody2D rigid;
    [SerializeField]GameObject parent;
    public Transform house;
    private void Awake()
    {
        monster = GetComponent<Monster>();
        parent = transform.parent.gameObject;
        rigid = GetComponent<Rigidbody2D>();
        
        house = GameObject.Find("House").GetComponent<Transform>();

    }
    private void OnEnable()
    {
        monster.SetHead(0);
        gameObject.layer = 12;
        rigid.isKinematic = true;
    }
    private void Update()
    {
        if (parent.transform.GetChild(0).gameObject.activeSelf == false && GameManager4.instance.gameOver) //ǳ���� �����ع�������
        {   
            rigid.isKinematic = false;
            gameObject.layer = 13;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10; // �̰� ��� �ڿ��ش޶��ؼ� �̰͸��ٲ��� �̰Ͷ����� �ȵ�
            
        }
        if (parent.transform.GetChild(0).gameObject.activeSelf == false && !GameManager4.instance.gameOver) // ǳ���� ��������
        {
            Dead();
        }
        if (gameObject.layer == 13)
        {
            Tracking();
        }
    }
    void Dead()
    {
        monster.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision) //���ӿ���
    {
        if (collision.CompareTag("House") && gameObject.layer == 13)
        {
            monster.Attack();
            HpManager.instance.SetHp(-1);
        }
    }
    public void Tracking()
    {
        if (gameObject.layer == 13)
        {
            float dis = Vector3.Distance(transform.position, house.position); //����ġ�� target�� ��ġ ������ �Ÿ��� ����
            if (dis <= 10) // �Ÿ��� 10ĭ ������ ���������� �i�� ����
            {
                Move();
            }
            else return;
        }

    }
    void Move()
    {
        float dir = house.position.x - transform.position.x; //2d�̱⿡ �¿츸 ����� (��x��ġ - targetx��ġ)
        dir = (dir < 0) ? -1 : 1; //�������� dir�� x�Ÿ��� -��� -1,�ƴϸ� 1
        transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
    }
}
