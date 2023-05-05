using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    public float speed = 2f;  // �̵� �ӵ�
    public float minX = -10f; // �ּ� x ��ǥ
    public float maxX = 10f;  // �ִ� x ��ǥ
    public GameObject[] item;
    bool moveRight;  // ���������� �̵� ������ ����
    private void Start()
    {
        StartCoroutine("SpawnItem");
    }
    void Update()
    {

            Move();
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
    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            Instantiate(item[Random.Range(0, 2)], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
}
