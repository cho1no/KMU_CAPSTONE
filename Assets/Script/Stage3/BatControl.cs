using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    public float speed = 2f;  // 이동 속도
    public float minX = -10f; // 최소 x 좌표
    public float maxX = 10f;  // 최대 x 좌표
    public GameObject[] item;
    bool moveRight;  // 오른쪽으로 이동 중인지 여부
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
        // x축 이동 방향 설정
        if (transform.position.x >= maxX)
        {
            moveRight = false;
            transform.localScale = new Vector3(0.4f, 0.4f, 1); //오른쪽 모습   
        }
        else if (transform.position.x <= minX)
        {
            moveRight = true;
            transform.localScale = new Vector3(-0.4f, 0.4f, 1); //왼쪽 모습 
        }

        // 오브젝트를 좌우로 이동
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
