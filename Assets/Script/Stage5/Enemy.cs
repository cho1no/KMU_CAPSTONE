using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.FantasyMonsters.Scripts;

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

    Monster monster;
    Animator ani;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    AudioSource audioSource;
    public AudioClip EnemyDead;
    
    [SerializeField]bool isLive;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        monster = GetComponent<Monster>();
        audioSource = GetComponent<AudioSource>();
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
        //if (health < 0)
        //{
        //    isLive = false;
        //    Dead();
        //}
    }
    void OnEnable() // 프리팹으로 옮겨서 하이어라키에있는 target을 넣을 수 없음
    {
        target = GameManager5.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        if (isLive)
        {
            monster.SetHead(0);
        }
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
        if (collision.CompareTag("Bullet1") || collision.CompareTag("Bullet2") || isLive == true)
        {
            health -= collision.GetComponent<Bullet>().damage;//닿이면 bullet스크립트에서 데미지를 가져와 피가 깍인다
        }
        //if (health > 0) // live,hit action
        //{
                
        //}
         if(health < 0)
        {
            isLive = false;
            Dead();
            //die
        }
    }
    public void Dead()
    {
        int itemDrop = Random.Range(0, 100);
        if (itemDrop <= 80)
        {
            //Instantiate(item0prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop > 80 && itemDrop <= 85)
        {
            Instantiate(item1prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop > 85 && itemDrop <= 90)
        {
            Instantiate(item2prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop > 90 && itemDrop <= 95)
        {
            Instantiate(item3prefab, transform.position, Quaternion.identity);
        }
        else if (itemDrop > 95 && itemDrop <= 100)
        {
            Instantiate(item4prefab, transform.position, Quaternion.identity);
        }
        audioSource.clip = EnemyDead;
        audioSource.Play();
        Score.instance.GetScore(40);
        ani.SetBool("Dead", true);
        Invoke("DeadActive", 1f);
    }
    void DeadActive()
    {
        gameObject.SetActive(false);
    }
}
