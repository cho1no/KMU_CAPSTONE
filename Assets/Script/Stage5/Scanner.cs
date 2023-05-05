using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange; //길이
    public LayerMask targetLayer; //타겟 레이어
    public RaycastHit2D[] targets; //타겟
    public Transform nearestTarget; //가장 가까운 타겟

    private void Start()
    {
        scanRange = 6;
    }
    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0 , targetLayer);
        nearestTarget = GetNearest();
    }
    
    Transform GetNearest() //반환
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets) //캐스팅 결과 오브젝트를 하나씩 접근
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff <diff) //반복문을 돌며 가져온 거리가 저장된 거리보다 작으면 교체
            {
                diff = curDiff;
                result = target.transform; // 가장 작은 값은 타겟이 result가 된다.
            }
        }
        return result;
    }
}
