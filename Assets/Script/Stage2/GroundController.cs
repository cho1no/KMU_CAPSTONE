using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundController : MonoBehaviour
{
    [Header("Public")]
    public GameObject[] groundPrefab; // 생성할 땅 오브젝트
    public float groundSpeed = 3f; // 땅 이동 속도
    public int groundPattern;

    [Header("Private")]
    [SerializeField]
    private float groundWidth; //이동할 물체 너비

    public List<GameObject> groundList; // 생성한 땅 오브젝트를 담을 리스트

    void Start()
    {
        
        //초기 땅 생성
        GameObject FirstGround = Instantiate(groundPrefab[0], new Vector3(0, transform.position.y, 0), Quaternion.identity);
        
        //땅의 길이 저장
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
        // 생성한 땅 오브젝트들을 이동시키고, 화면 밖으로 나간 오브젝트는 리스트에서 제거
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
        // 땅 오브젝트 생성 및 리스트에 추가
        SpawnGround(groundPattern);
    }
    public void SpawnGround(int prefabNum)
    {
        // 땅 오브젝트 생성 및 리스트에 추가
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
