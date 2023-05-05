using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    int bulletSpeed;
    float liveTimer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet2"))
        {
            Dead();
            Score.instance.GetScore(20);
        }
    }
    private void Update()
    {
        liveTimer += Time.deltaTime;
        if (transform.position.y <= -5 || transform.position.x <= -5 || transform.position.x >= 5 || liveTimer > 5f)
        {
            Destroy(gameObject);
            liveTimer = 0;
        }
        Vector3 bulletPos = transform.position;
        Vector3 movePos = new Vector3(0, -1, 0) * bulletSpeed * Time.deltaTime;
        transform.position = bulletPos + movePos;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
