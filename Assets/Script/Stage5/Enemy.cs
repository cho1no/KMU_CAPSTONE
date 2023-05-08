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
    public GameObject item1prefab;
    public GameObject item2prefab;
    public GameObject item3prefab;
    public GameObject item4prefab;
    //public GameObject scoreItemprefab;

    Animator ani;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    
    [SerializeField]bool isLive;
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
        
        if (transform.position.x >= -2.4 && transform.position.x <= 1.85)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                shootTimer = 0;
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
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
        if (collision.CompareTag("Bullet1") || collision.CompareTag("Bullet2") && isLive == true)
        {
            health -= collision.GetComponent<Bullet>().damage;//닿이면 bullet스크립트에서 데미지를 가져와 피가 깍인다
        }
        if (health > 0) // live,hit action
        {
                
        }
        else if(health < 0)
        {
            isLive = false;
            Dead();
            //die
        }
    }
    public void Dead()
    {
        int itemDrop = Random.Range(0, 100);
        if (itemDrop < 80)
        {
            //Instantiate(item0prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 85 && itemDrop > 80)
        {
            Instantiate(item1prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 90 && itemDrop > 85)
        {
            Instantiate(item2prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 95 && itemDrop > 90)
        {
            Instantiate(item3prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop < 100 && itemDrop > 95)
        {
            Instantiate(item4prefab, transform.position, Quaternion.identity);
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
