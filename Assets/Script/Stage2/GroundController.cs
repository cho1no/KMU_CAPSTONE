using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundController : MonoBehaviour
{
    [Header("Public")]
    public GameObject[] groundPrefab; // ������ �� ������Ʈ
    public float groundSpeed = 3f; // �� �̵� �ӵ�
    public int groundPattern;

    [Header("Private")]
    [SerializeField]
    private float groundWidth; //�̵��� ��ü �ʺ�

    public List<GameObject> groundList; // ������ �� ������Ʈ�� ���� ����Ʈ

    void Start()
    {
        
        //�ʱ� �� ����
        GameObject FirstGround = Instantiate(groundPrefab[0], new Vector3(0, transform.position.y, 0), Quaternion.identity);
        
        //���� ���� ����
        Renderer renderer = FirstGround.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;
        groundWidth = size.x;

        GameObject SecondGround = Instantiate(groundPrefab[0], new Vector3(-groundWidth, transform.position.y, 0), Quaternion.identity);
        GameObject ThirdGround = Instantiate(groundPrefab[0], new Vector3(-groundWidth * 2, transform.position.y, 0), Quaternion.identity);

        groundList = new List<GameObject>();
        groundList.Add(FirstGround);
        groundList.Add(SecondGround);
        groundList.Add(ThirdGround);
        FirstGround.transform.SetParent(this.transform);
        SecondGround.transform.SetParent(this.transform);
        ThirdGround.transform.SetParent(this.transform);
        ChangeLayersRecursively(FirstGround.transform, this.gameObject.layer);
        ChangeLayersRecursively(SecondGround.transform, this.gameObject.layer);
        ChangeLayersRecursively(ThirdGround.transform, this.gameObject.layer);
    }
    void Update()
    {
        GroundControl();
    }
    void GroundControl()
    {
        // ������ �� ������Ʈ���� �̵���Ű��, ȭ�� ������ ���� ������Ʈ�� ����Ʈ���� ����
        foreach (GameObject ground in groundList)
        {
            ground.transform.Translate(Vector3.left * -groundSpeed * Time.deltaTime);

            if (ground.transform.position.x > groundWidth)
            {
                groundList.Remove(ground);
                Destroy(ground);
                RandomGround();
                break;
            }
        }
    }
    void RandomGround()
    {
        int random = Random.Range(0, 100);
        switch (random)
        {
            case <= 40:
                groundPattern = 0;
                break;
            case int n when (40 < n && n <= 70):
                groundPattern = 1;
                break;
            case int n when (70 < n && n <= 80):
                groundPattern = 2;
                break;
            case int n when (80 < n && n <= 90):
                groundPattern = 3;
                break;
            case > 90:
                groundPattern = 4;
                break;
        }
        // �� ������Ʈ ���� �� ����Ʈ�� �߰�
        SpawnGround(groundPattern);
    }
    public void SpawnGround(int prefabNum)
    {
        // �� ������Ʈ ���� �� ����Ʈ�� �߰�
        GameObject newGround = Instantiate(groundPrefab[prefabNum], new Vector3(groundList[groundList.Count - 1].transform.position.x - groundWidth, transform.position.y, 0), Quaternion.identity);

        groundList.Add(newGround);
        newGround.transform.SetParent(this.transform);
        ChangeLayersRecursively(newGround.transform, this.gameObject.layer);
    }
    public static void ChangeLayersRecursively(Transform trans, int num)
    {
        trans.gameObject.layer = num;
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, num);
        }
    }
}
