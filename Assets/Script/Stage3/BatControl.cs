using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    public float speed = 2f;  // 이동 속도
    public float minX = -10f; // 최소 x 좌표
    public float maxX = 10f;  // 최대 x 좌표
    public float downSpeed;
    public GameObject[] item;
    bool moveRight;  // 오른쪽으로 이동 중인지 여부
    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Rock"))
        {
            //ani.SetTrigger("Dead");
            ani.SetBool("Deadd", true);
            Debug.Log("닿았다");
            downSpeed = -3;
            speed = 0;
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            gameObject.SetActive(false);
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
