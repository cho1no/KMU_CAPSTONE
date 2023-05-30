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
    public GameObject Get(int index)//���ӿ�����Ʈ ��ȯ �Լ�
    {
        GameObject select = null;

        //������ Ǯ�� ��� �ִ�(��Ȱ��ȭ ��) ���ӿ�����Ʈ ����
        //�߰��ϸ� select ������ �Ҵ�
        foreach (GameObject item in pools[index]) // �迭�̳� ����Ʈ�� �������� �ݺ���
        {
            if (item != null)
            {
                if (!item.activeSelf) // activeself ������Ʈ�� ��Ȱ��ȭ(������)���� Ȯ��
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }
        }
        //�� ã������ ���Ӱ� �����Ͽ� select ������ �Ҵ� 
        if (!select) //���Ӱ� �����ϰ� select ������ �Ҵ�
        {
            select = Instantiate(prefab[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
