using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.FantasyMonsters.Scripts;

public class BatControl : MonoBehaviour
{
    public float speed = 2f;  // �̵� �ӵ�
    public float minX = -10f; // �ּ� x ��ǥ
    public float maxX = 10f;  // �ִ� x ��ǥ
    public float downSpeed;
    public GameObject[] item;
    bool moveRight;  // ���������� �̵� ������ ����
    Monster monster;
    private void Awake()
    {
        monster = GetComponent<Monster>();
    }
    private void Start()
    {
        StartCoroutine("SpawnItem");
    }
    void Update()
    {

            Move();
        transform.Translate(new Vector3(0, downSpeed, 0) * Time.deltaTime);
    }
    private void Move()
    {
        // x�� �̵� ���� ����
        if (transform.position.x >= maxX)
        {
            moveRight = false;
            transform.localScale = new Vector3(0.4f, 0.4f, 1); //������ ���   
        }
        else if (transform.position.x <= minX)
        {
            moveRight = true;
            transform.localScale = new Vector3(-0.4f, 0.4f, 1); //���� ��� 
        }

        // ������Ʈ�� �¿�� �̵�
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Rock"))
        {
            //ani.SetTrigger("Dead");
            Debug.Log("��Ҵ�");
            downSpeed = -3;
            speed = 0;
            monster.Die();
            gameObject.tag = "Untagged";
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            gameObject.SetActive(false);
            monster.SetHead(2);
            gameObject.tag = "Enemy";
        }
    }
    
    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            Instantiate(item[Random.Range(0, 2)], new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
    void Dead()
    {

    }
}
