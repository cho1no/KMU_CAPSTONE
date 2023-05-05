using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttackBox : MonoBehaviour
{
    private float timeColider = 0.3f;
    private float timeCurrent = 0;
    // Update is called once per frame
    void Update()
    {
        if (timeCurrent < timeColider)
        {
            timeCurrent += Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
