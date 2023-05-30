using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPool : MonoBehaviour
{
    public static BalloonPool instance;

    public GameObject[] prefab;

    List<GameObject>[] pools;
    private void Awake()
    {
        instance = this;
        pools = new List<GameObject>[prefab.Length];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)//게임오브젝트 반환 함수
    {
        GameObject select = null;

        //선택한 풀의 놀고 있는(비활성화 된) 게임오브젝트 접근
        //발견하면 select 변수에 할당
        foreach (GameObject item in pools[index]) // 배열이나 리스트에 순차적인 반복문
        {
            if (item != null)
            {
                if (!item.activeSelf) // activeself 오브젝트가 비활성화(대기상태)인지 확인
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }
        }
        //못 찾았으면 새롭게 생성하여 select 변수에 할당 
        if (!select) //새롭게 생성하고 select 변수에 할당
        {
            select = Instantiate(prefab[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
