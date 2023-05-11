using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float cooltime;

    
    float timer;
    [SerializeField] float itemTimer, liveTime = 30;
    //public bool isLive = true;

    ItemWeapon itemWeapon;
    AudioSource audioSource;
    public AudioClip shotNormal;
    private void Awake()
    {
        //부모 오브젝트 컴포넌트 가져오는방법
        itemWeapon = GetComponentInParent<ItemWeapon>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Init();
        switch (id) //무기 아이디에 따른
        {
            case 0: 
                timer += Time.deltaTime;
                itemTimer += Time.deltaTime;
                if (timer > cooltime)
                {
                    timer = 0f;
                    Normal();
                }
                if (itemTimer > 30)
                {
                    DestroyItem();
                    GameManager5.instance.weapon.count--;      
                }
                if (itemTimer >= 27)
                {
                    StartCoroutine(Warning());
                }
                break;
            case 1: //유도 미사일
                timer += Time.deltaTime;
                itemTimer += Time.deltaTime;
                if (timer > cooltime)
                {
                    timer = 0f;
                    Fire();
                }
                if (itemTimer > 30)
                {
                    DestroyItem();
                    GameManager5.instance.weapon.count--;
                }
                if (itemTimer >= 27)
                {
                    StartCoroutine(Warning());
                }
                break;
            case 2://무기회전
                transform.Rotate(Vector3.back * cooltime * Time.deltaTime);
                break;
            case 3:
                timer += Time.deltaTime;

                if (timer > cooltime)
                {
                    timer = 0f;
                    Normal();
                }
                break;
            case 4:
                timer += Time.deltaTime;
                itemTimer += Time.deltaTime;
                if (timer > cooltime)
                {
                    timer = 0f;
                    Normal();
                }
                if (itemTimer > 30)
                {
                    DestroyItem();
                    GameManager5.instance.weapon.count--;
                }
                if (itemTimer >= 27)
                {
                    StartCoroutine(Warning());
                }
                break;
            default:


                break;
        }
    }
    //public void LevelUp(float damage, float cooltime)
    //{
    //    this.damage = damage;
    //    this.cooltime = cooltime;
    //}
    public void Init()
    {
        switch (id)
        {
            case 0: //무기 관통 공격 무기1
                cooltime = 1f;
                break;
            case 1: //유도 미사일 무기2
                cooltime = 2f;
                break;
            case 2: //무기회전
                cooltime = 80;
                RotationWeapon();
                break;
            case 3://플레이어 공격
                cooltime = 0.3f;
                break;
            case 4: //무기3
                cooltime = 0.3f;
                break;
            default:

                break;
        }
    }
    void Fire() //유도 미사일
    {
        if (!itemWeapon.scanner.nearestTarget)  //아이템에 부여할거면 플레이어가 아닌 총알에 넣자 
            return;
 
        Vector3 targetPos = itemWeapon.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized; //매그니튜드는 벡터의 크기

        Transform bullet1 = GameManager5.instance.pool.Get(prefabId).transform;
        bullet1.position = transform.position;
        bullet1.rotation = Quaternion.FromToRotation(Vector3.up, dir); //지정된 축을 중심으로 목표를 향해 회전하는 함수
        bullet1.GetComponent<Bullet>().Init(damage,count, dir);
    }
    void Normal() //플레이어 일반공격
    {
        audioSource.clip = shotNormal;
        audioSource.Play();
        Transform bullet0 = GameManager5.instance.pool.Get(prefabId).transform;
        bullet0.position = new Vector3(transform.position.x , transform.position.y + 1 ,transform.position.z);
        bullet0.GetComponent<Bullet>().Init(damage, count, new Vector3(0,1,0));
    }
    public void RotationWeapon() //아이템 회전
    {

        for (int index = 0; index < count; index++)  //count 1이상 시 30초마다 count -1
        {
            Transform weaponCircle;
            if (index < transform.childCount) // 갯수확인
            {
                weaponCircle = transform.GetChild(index); // index가 아직 childcount 범위 내라면 get child함수 가져오기, 기존 오브젝트를 사용하다가
            }
            else
            {
                weaponCircle = GameManager5.instance.pool.Get(prefabId).transform; //아이템1,2 가져오기
                weaponCircle.parent = transform; //bullet의 부모를 itemWeapon에 넣었다.
            }
            weaponCircle.localPosition = Vector3.zero; // 위치 초기화
            weaponCircle.localRotation = Quaternion.identity; // 위치 초기화
            Vector3 rotVec = Vector3.forward * 360 * index / count;  // 4/360
            weaponCircle.Rotate(rotVec);
            weaponCircle.Translate(weaponCircle.up * 0.7f, Space.World);
            weaponCircle.transform.rotation = Quaternion.Euler(0,0, 0);
        }
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
       
    }
    IEnumerator Warning()
    {

        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.3f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1f);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.3f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1f);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.3f);
        color.a = 1f;

    }
}

