using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager : MonoBehaviour
{
    //������ ������ ���� 2��������
    public GameObject[] prefabs;

    //Ǯ ����� �ϴ� ����Ʈ�� 2���ʿ�
    List<GameObject>[] pools;
    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //���� �ڵ�����
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)//���ӿ�����Ʈ ��ȯ �Լ�
    {
        GameObject select = null;

        //������ Ǯ�� ��� �ִ�(��Ȱ��ȭ ��) ���ӿ�����Ʈ ����
        //�߰��ϸ� select ������ �Ҵ�
        foreach(GameObject item in pools[index]) // �迭�̳� ����Ʈ�� �������� �ݺ���
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
        if(!select) //���Ӱ� �����ϰ� select ������ �Ҵ�
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); 
        }
        return select;
    }
}
