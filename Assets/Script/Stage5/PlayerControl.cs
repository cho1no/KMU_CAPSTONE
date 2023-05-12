using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    float speed = 2; //플레이어 이동 속도

    public GameObject bomb;
    GameObject bombExp;
    public GameObject gameOver;
    public Animator ani;
    Vector2 moveLimit = new Vector2(2.1f, 0);

    [Header("Boom")]
    private int maxBoom;

    public Image[] boomImage;
    public int boomCount { get; private set; }

    public bool isLive;
    private void Awake()
    {
        instance = this;
        maxBoom = boomImage.Length;
        boomCount = maxBoom;
        for (int i = 0; i < maxBoom; i++)
        {
            if (boomCount > i)
            {
                boomImage[i].sprite = boomImage[0].sprite;
            }
        }
    }
    private void Start()
    {
        isLive = true;
        
    }
    void Update()
    {
        LimitScreen();
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
    public void RedButton() // 좌우 방향 이동
    {
        speed = -2;
    }
    public void blueButton()
    {
        speed = 2;
    }
    public void yellowButton()
    {
        ItemBoom(-1);
        
    }
    void LimitScreen()
    {
        transform.position = ClampPosition(transform.position);
    }
    public Vector3 ClampPosition(Vector3 pos)
    {
        return new Vector3(Mathf.Clamp(pos.x, -moveLimit.x, moveLimit.x), -2.6f, 0);
    }
    //void OnAbsolute()
    //{
    //    gameObject.tag = "Abs";
    //    Invoke("OffAbsolute", 2);
    //}
    //void OffAbsolute()
    //{
    //    gameObject.tag = "Player";
    //}

    public void setBoom(int boom)
    {
        //for (int i = 0; i < maxBoom; i++)
        //{
        //    boomImage[i].color = new Color(1, 1, 1, 0);
        //}
        //for (int i = 0; i < boomCount; i++)
        //{
        //    boomImage[i].color = new Color(1, 1, 1, 1);
        //}
        //if (boomCount >= maxBoom)
        //{
        //    boomCount = maxBoom;
        //}
        boomCount += boom;
        boomCount = Mathf.Clamp(boomCount, 0, maxBoom);
        for (int i = 0; i < maxBoom; i++)
        {
            boomImage[i].transform.gameObject.SetActive(false);
        }
        for (int i =0; i < maxBoom; i++)
        {
            if (boomCount > i)
            {
                boomImage[i].transform.gameObject.SetActive(true);
            }
        }
    }
    public void ItemBoom(int val)
    {
        if (boomCount > 0)
        {
            bombExp = Instantiate(bomb, new Vector3(0, 0, 0), Quaternion.identity);
            Invoke("DestroyBomb", 1f);
            setBoom(val);
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] bullet = GameObject.FindGameObjectsWithTag("BulletEnemy");

            if (bullet != null && bullet.Length != 0)
            {
                for (int i = bullet.Length - 1; i >= 0; i--)
                {
                    bullet[i].GetComponent<EnemyBullet>().Dead();
                }
            }
            if (enemy != null && enemy.Length != 0)
            {
                for (int i = enemy.Length - 1; i >= 0; i--)
                {
                    enemy[i].GetComponent<Enemy>().Dead();
                }
            }
        }
    }
    void DestroyBomb()
    {
        Destroy(bombExp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLive == true)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Boss") || collision.CompareTag("BulletEnemy"))
            {
                HpManager.instance.SetHp(-1);
            }
        }
    }

}
