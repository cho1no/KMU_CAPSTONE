using System.Collections;
using System.Collections.Generic;
using Assets.FantasyMonsters.Scripts;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public enum BossType { boss1, boss2, boss3, boss4, boss5 }
    public BossType type;
    [SerializeField] float bossMovement, patternTimer = 40, bulletSpeed, fireRate1, fireRate2, fireRate3, nextFire, resetTimer = 70f, radius, health;
    [SerializeField] int pathNum, currentState, numberOfBullets = 10; //패턴2 총알 갯수

    public GameObject point;
    public GameObject bulletPrefab;
    public GameObject spawner;
    public Rigidbody2D bullet;
    public Transform[] wayPoint;

    bool isLive;
    Animator ani;
    //public GameObject spawn5;
    Monster monster;
    private void Awake()
    {
        point = GameObject.Find("WayPoint");
        wayPoint = point.GetComponentsInChildren<Transform>();
        spawner = GameObject.Find("Spawner");
        ani = GetComponent<Animator>();
        monster = GetComponent<Monster>();
    }
    private void OnEnable()
    {
        isLive = true;
        if (isLive)
        {
            monster.SetHead(0);
        }
    }
    private void Start()
    {
        switch (type)
        {
            case BossType.boss1:
                health = 50;
                numberOfBullets = 10;
                bossMovement = 1.3f;
                bulletSpeed = 1.8f;
                break;
            case BossType.boss2:
                health = 75;
                numberOfBullets = 12;
                bossMovement = 1.5f;
                bulletSpeed = 1.8f;
                break;
            case BossType.boss3:
                health = 100;
                numberOfBullets = 14;
                bossMovement = 1.5f;
                bulletSpeed = 1.8f;
                break;
            case BossType.boss4:
                health = 125;
                numberOfBullets = 16;
                bossMovement = 1.7f;
                bulletSpeed = 1.8f;
                break;
            case BossType.boss5:
                health = 150;
                numberOfBullets = 18;
                bossMovement = 1.9f;
                bulletSpeed = 1.8f;
                break;
        }
    }
    void Update()
    {
        patternTimer -= Time.deltaTime;
        if (patternTimer <= 10)
        {
            currentState = 1;
        }
        else if (patternTimer <= 40 && patternTimer > 20)
        {
            currentState = 2;
        }
        else if (patternTimer <= 20 && patternTimer >= 10)
        {
            currentState = 3;
        }
        if (patternTimer < 0)
        {
            patternTimer = resetTimer;
        }

        if (currentState == 1)
        {
            RandomFirePattern1();
            bossMovement = 1.3f;
            transform.position = Vector2.MoveTowards(transform.position, wayPoint[pathNum].transform.position, bossMovement * Time.deltaTime); //이동
            if (Vector2.Distance(transform.position, wayPoint[pathNum].transform.position) < 0.1) //포인트에 도달하면 다음 포인트로 이동transform.position == path[pathNum].transform.position
            {
                pathNum++;
                if (pathNum == wayPoint.Length)
                {
                    pathNum = 1;
                }
            }
        }

        else if (currentState == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[7].transform.position, bossMovement * Time.deltaTime);
            CireFirePattern2();
        }

        else if (currentState == 3)
        {
            TrippleAttackPattern3();
        }
    }
    private void LateUpdate()//데이터 정리
    {



    }
    void RandomFirePattern1()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate1;
            Vector3 bulletPosition = new Vector3(Random.Range(-2.0f, 2.0f), 3, 0);
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(0, -bulletSpeed);
        }

    }
    void CireFirePattern2()
    {
        //1번쨰
        // 다음 공격 시간이 되었는지 확인
        if (Time.time > nextFire)
        {
            // 다음 공격 시간 갱신
            nextFire = Time.time + fireRate2;

            // 총알 발사
            for (int i = 0; i < numberOfBullets; i++)
            {
                // 원형 공격 패턴 계산
                float angle = i * Mathf.PI * 2f / numberOfBullets;
                Vector3 spawnPosition = transform.position + new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0f);

                // 총알 생성
                GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

                // 총알 발사
                Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.velocity = new Vector2(bulletSpeed * Mathf.Cos(angle), bulletSpeed * Mathf.Sin(angle));
            }
        }
    }
    public void TrippleAttackPattern3()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate3;

            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + Vector3.left * 0.7f, Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + Vector3.right * 0.7f, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(0, -bulletSpeed);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health < 0)
            return;
        if (collision.CompareTag("Bullet1") || collision.CompareTag("Bullet2"))
        {
            Debug.Log(health);
            health -= collision.GetComponent<Bullet>().damage;
            Score.instance.GetScore(30);
        }
        if (health > 0)
        {

        }
        else if (health <= 0)
        {
            OnDie();
        }
    }
    public void OnDie()
    {

        Score.instance.GetScore(5000);
        ani.SetBool("Dead", true);
        Invoke("DeadActive", 1f);

    }
    public void DeadActive()
    {
        Destroy(gameObject);
        spawner.SetActive(true);
    }
}
