using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;
    public float bulletSpeed;

    Rigidbody2D rigid;
    float timer;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.3)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
    public void Init(float damage, int per ,Vector3 dir)
    {
        this.damage = damage;
        this.per = per;
        if (per > -1) //원거리 무기감지 관통
        {
            rigid.velocity = dir * bulletSpeed; //총알이동속도
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || !collision.CompareTag("Boss"))
            return;
         
        per--;
        if(per == -1) 
        { 
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
