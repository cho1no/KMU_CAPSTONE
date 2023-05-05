using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public Transform target;
    float scrollRange = 19.8f;
    float targetSize = 9.9f;
    float moveSpeed = 1.5f;
    Vector3 MoveDirection = Vector3.down;
    void Update()
    {
        transform.position += MoveDirection * moveSpeed * Time.deltaTime; // 배경이 moveDirection 방향으로 speed로 간다
        //target 위로 이동
        if(transform.position.y <= -targetSize)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}
