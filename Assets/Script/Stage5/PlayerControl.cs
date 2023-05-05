using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    float speed = 2; //플레이어 이동 속도
    public int boomCount = 3;
    public GameObject gameOver;
    public Animator ani;
    Vector2 moveLimit = new Vector2(2.1f, 0);

    public bool isLive;
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
        //OnAbsolute();
        ItemBoom();
        boomCount--;
        //hpManager.SetHp(-1);
        
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

    void ItemBoom()
    {
        if (boomCount > 0)
        {
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
