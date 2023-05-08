using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveEx : MonoBehaviour
{
    
    public ComboText combotext;
    public ComboCount combocount;
    public float speed;
    public AudioSource hitSound;
    public PlayerRotation playerRotation;
    public Spawner spawner; 
    public Transform target;
    Animator ani;
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    public bool isLive;
    float rotateSpeed = 540f;
    [SerializeField]
    float liveTimer;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        combotext = GameObject.Find("Combo").GetComponent<ComboText>();
        combocount = GameObject.Find("ComboCount").GetComponent<ComboCount>();
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        playerRotation = GameObject.Find("player").GetComponent<PlayerRotation>();
        spawner = GameObject.Find("spawner").GetComponent<Spawner>();
        target = GameObject.Find("player").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        isLive = true;
    }
    void Update()
    {

            if (target.position.x < rigid.position.x)
                transform.localScale = new Vector3(0.15f, 0.15f, 1); //오른쪽 모습   
            else
            {
                transform.localScale = new Vector3(-0.15f, 0.15f, 1);  //왼쪽 모습
            }
            if (isLive == false)
            {
                HitAni();
                liveTimer += Time.deltaTime;
                if (liveTimer > 0.3f)
                {
                    isLive = true;
                    liveTimer = 0;
                }
            }
            if (isLive == true)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            Tracking();
            OnDestroy();

    }
    public void Tracking()
    {
        if (transform.position.y <= -1.8f)
        {
            float dis = Vector3.Distance(transform.position, target.position); //내위치와 target의 위치 사이의 거리를 구함
            if (dis <= 10) // 거리가 10칸 안으로 좁혀졌으면 쫒기 시작
            {
                Move();
            }
            else return;
        }
       
    }
    void Move()
    {
        float dir = target.position.x - transform.position.x; //2d이기에 좌우만 빼면됨 (내x위치 - targetx위치)
        dir = (dir < 0) ? -1 : 1; //방향조절 dir의 x거리가 -라면 -1,아니면 1
        transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            isLive = false;
            ani.SetBool("Death", true);
            if (playerRotation.speed > 0)
            {
                Vector3 speed1 = new Vector3(-80, 950, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            else
            {
                Vector3 speed1 = new Vector3(80, 950, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            combotext.combo++;
            combotext.Ani();
            combocount.Ani();
            Score.instance.GetScore(50);
            hitSound.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.SetTrigger("Attack");
        }
    }
    public void OnDestroy()
    {
        if (transform.position.y >= 13)
        {
            gameObject.SetActive(false);
        }
    }
    public void HitAni()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);   //rotate 지속적 회전 roatation 정해진 값 회전을 대입
    }
}
