using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public ComboText combotext;
    public ComboCount combocount;
    public GameObject gameOver;
    public PlayerAnimation ani;
    public float speed = 1;
    int playerLife = 4;
    private Rigidbody2D rigid;

    private bool ishit;
    SpriteRenderer spriter;
    Vector2 moveLimit = new Vector2(7f, 0);

    public Animator Ani;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            ScreenLimit();
    }
    public void RedButton()
    {
        speed *= -1;
        if (speed !=0)
        {
            spriter.flipX = speed < 0;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !ishit)//늑대
        {
            ishit = true;
            if (speed < 0)
            {
                OnDamaged();
                Vector3 speed1 = new Vector3(-150, 150, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
                Handheld.Vibrate();
            }
            else
            {
                OnDamaged();
                Vector3 speed1 = new Vector3(100, 100, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
                Handheld.Vibrate();
            }
            HpManager.instance.SetHp(-1);
            TotalSound.instance.PlayerHit();
            ani.hitmotion();
            combotext.combo = 0;
            combotext.Ani();
            combocount.Ani();
            StartCoroutine(Hit());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock" && !ishit)//돌맹이
        {
            ishit = true;
            HpManager.instance.SetHp(-1);
            TotalSound.instance.PlayerHit();
            ani.hitmotion();
            combotext.combo = 0;
            combotext.Ani();
            combocount.Ani();
            StartCoroutine(Hit());
            Handheld.Vibrate();
        }
        if (collision.gameObject.tag.Equals("HpItem"))
        {
            HpManager.instance.SetHp(1);
            TotalSound.instance.GetHpItem();
            Destroy(collision.gameObject);
        }
    }
    public void OnDamaged()
    {
        gameObject.layer = 8;
        Invoke("OffDamaged", 3f);
    }
    public void OffDamaged()
    {
        gameObject.layer = 7;
    }
    IEnumerator Hit()
    {
        int countTime = 0;
        while (countTime <= 10)//0.2초마다 countTime++ 즉 무적시간은 0.2*10 = 2초
        {
            if (countTime % 2 == 0) spriter.color = new Color32(255, 255, 255, 90);
            else spriter.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriter.color = new Color32(255, 255, 255, 255);
        ishit = false;
        Debug.Log("ishit = false");
        yield return null;
    }
    public void ScreenLimit() //플레이어 화면 밖으로 안나가게 하기
    {
        transform.localPosition = ClampPosition(transform.position);
    }
    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3(Mathf.Clamp(position.x, -moveLimit.x, moveLimit.x), -2f, 0);
    }
    //public void GameOver()
    //{
    //    if(playerLife == 0)
    //    {
    //        //죽는 애니메이션
    //        StartCoroutine(GameOverRoutine());
    //        //게임오버 팜플렛 띄우기
    //    }
    //}
    //IEnumerator GameOverRoutine()
    //{
    //    yield return new WaitForSeconds(0.7f);

    //    Stop();
        
    //    gameOver.SetActive(true);
    //}
    //void Stop()
    //{
    //    Time.timeScale = 0;
    //}

}
