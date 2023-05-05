using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float shootInterval;
    public Rigidbody2D target;
    
    public float shootTimer = 0;

    public GameObject bulletPrefab;
    public GameObject item0prefab;
    public GameObject item1prefab;
    public GameObject item2prefab;
    //public GameObject scoreItemprefab;

    Animator ani;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    
    bool isLive;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (!isLive)
            return;
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
    void OnEnable() // 프리팹으로 옮겨서 하이어라키에있는 target을 넣을 수 없음
    {
        target = GameManager5.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }
    public void Init(SpawnData data)
    {
        shootInterval = data.shootInterval;
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health <= 0 )
            return;
        if (collision.CompareTag("Bullet1") || collision.CompareTag("Bullet2"))
        {
            health -= collision.GetComponent<Bullet>().damage;//닿이면 bullet스크립트에서 데미지를 가져와 피가 깍인다
        }
            if (health > 0) // live,hit action
        {

        }
        else
        {
            Dead();
            //die
        }
    }
    public void Dead()
    {
        int itemDrop = Random.Range(0, 10);
        if (itemDrop < 5)
        {
            //Instantiate(item0prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 6)
        {
            Instantiate(item0prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 7)
        {
            Instantiate(item1prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 8)
        {
            Instantiate(item2prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 10)
        {
            //Instantiate(scoreItemprefab, transform.position, Quaternion.identity);
        }
        
        Score.instance.GetScore(40);
        ani.SetBool("Dead", true);
        Invoke("asdf", 1f);
    }
    void asdf()
    {
        gameObject.SetActive(false);
    }
}
