using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask noteTargetLayer; // Ÿ�� ���̾�
    public RaycastHit2D[] noteTargets; // Ÿ��
    public RectTransform nearstTarget; //���� ����� Ÿ��

    private void Start()
    {
        scanRange = 600;
    }
    private void FixedUpdate()
    {
        noteTargets = Physics2D.CircleCastAll(transform.localPosition, scanRange, Vector2.zero, 0, noteTargetLayer);
        nearstTarget = GetNearest();
    }
    RectTransform GetNearest() //��ȯ
    {
        RectTransform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in noteTargets) //ĳ���� ��� ������Ʈ�� �ϳ��� ����
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff) //�ݺ����� ���� ������ �Ÿ��� ����� �Ÿ����� ������ ��ü
            {
                diff = curDiff;
                result = (RectTransform)target.transform; // ���� ���� ���� Ÿ���� result�� �ȴ�.
            }
        }
        return result;
    }
}
