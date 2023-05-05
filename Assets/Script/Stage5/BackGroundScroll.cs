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
        transform.position += MoveDirection * moveSpeed * Time.deltaTime; // ����� moveDirection �������� speed�� ����
        //target ���� �̵�
        if(transform.position.y <= -targetSize)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}
