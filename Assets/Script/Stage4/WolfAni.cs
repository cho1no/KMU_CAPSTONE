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
        if (parent.transform.GetChild(0).gameObject.activeSelf == false && GameManager4.instance.gameOver) //풍선이 도착해버렸을때
        {   
            rigid.isKinematic = false;
            gameObject.layer = 13;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10; // 이거 배경 뒤에해달라해서 이것만바꿨음 이것때문에 안됨
            
        }
        if (parent.transform.GetChild(0).gameObject.activeSelf == false && !GameManager4.instance.gameOver) // 풍선이 터졌을때
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
    private void OnTriggerEnter2D(Collider2D collision) //게임오버
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
            float dis = Vector3.Distance(transform.position, house.position); //내위치와 target의 위치 사이의 거리를 구함
            if (dis <= 10) // 거리가 10칸 안으로 좁혀졌으면 쫒기 시작
            {
                Move();
            }
            else return;
        }

    }
    void Move()
    {
        float dir = house.position.x - transform.position.x; //2d이기에 좌우만 빼면됨 (내x위치 - targetx위치)
        dir = (dir < 0) ? -1 : 1; //방향조절 dir의 x거리가 -라면 -1,아니면 1
        transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
    }
}
