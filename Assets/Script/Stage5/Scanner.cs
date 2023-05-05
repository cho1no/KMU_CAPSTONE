using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange; //����
    public LayerMask targetLayer; //Ÿ�� ���̾�
    public RaycastHit2D[] targets; //Ÿ��
    public Transform nearestTarget; //���� ����� Ÿ��

    private void Start()
    {
        scanRange = 6;
    }
    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0 , targetLayer);
        nearestTarget = GetNearest();
    }
    
    Transform GetNearest() //��ȯ
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets) //ĳ���� ��� ������Ʈ�� �ϳ��� ����
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff <diff) //�ݺ����� ���� ������ �Ÿ��� ����� �Ÿ����� ������ ��ü
            {
                diff = curDiff;
                result = target.transform; // ���� ���� ���� Ÿ���� result�� �ȴ�.
            }
        }
        return result;
    }
}
