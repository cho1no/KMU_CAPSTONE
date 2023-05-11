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
        //�θ� ������Ʈ ������Ʈ �������¹��
        itemWeapon = GetComponentInParent<ItemWeapon>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Init();
        switch (id) //���� ���̵� ����
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
            case 1: //���� �̻���
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
            case 2://����ȸ��
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
            case 0: //���� ���� ���� ����1
                cooltime = 1f;
                break;
            case 1: //���� �̻��� ����2
                cooltime = 2f;
                break;
            case 2: //����ȸ��
                cooltime = 80;
                RotationWeapon();
                break;
            case 3://�÷��̾� ����
                cooltime = 0.3f;
                break;
            case 4: //����3
                cooltime = 0.3f;
                break;
            default:

                break;
        }
    }
    void Fire() //���� �̻���
    {
        if (!itemWeapon.scanner.nearestTarget)  //�����ۿ� �ο��ҰŸ� �÷��̾ �ƴ� �Ѿ˿� ���� 
            return;
 
        Vector3 targetPos = itemWeapon.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized; //�ű״�Ʃ��� ������ ũ��

        Transform bullet1 = GameManager5.instance.pool.Get(prefabId).transform;
        bullet1.position = transform.position;
        bullet1.rotation = Quaternion.FromToRotation(Vector3.up, dir); //������ ���� �߽����� ��ǥ�� ���� ȸ���ϴ� �Լ�
        bullet1.GetComponent<Bullet>().Init(damage,count, dir);
    }
    void Normal() //�÷��̾� �Ϲݰ���
    {
        audioSource.clip = shotNormal;
        audioSource.Play();
        Transform bullet0 = GameManager5.instance.pool.Get(prefabId).transform;
        bullet0.position = new Vector3(transform.position.x , transform.position.y + 1 ,transform.position.z);
        bullet0.GetComponent<Bullet>().Init(damage, count, new Vector3(0,1,0));
    }
    public void RotationWeapon() //������ ȸ��
    {

        for (int index = 0; index < count; index++)  //count 1�̻� �� 30�ʸ��� count -1
        {
            Transform weaponCircle;
            if (index < transform.childCount) // ����Ȯ��
            {
                weaponCircle = transform.GetChild(index); // index�� ���� childcount ���� ����� get child�Լ� ��������, ���� ������Ʈ�� ����ϴٰ�
            }
            else
            {
                weaponCircle = GameManager5.instance.pool.Get(prefabId).transform; //������1,2 ��������
                weaponCircle.parent = transform; //bullet�� �θ� itemWeapon�� �־���.
            }
            weaponCircle.localPosition = Vector3.zero; // ��ġ �ʱ�ȭ
            weaponCircle.localRotation = Quaternion.identity; // ��ġ �ʱ�ȭ
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

