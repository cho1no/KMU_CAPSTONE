using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    GroundController groundspeed;//ground 속도를 받아오기위함
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        groundspeed = GameObject.Find("Ground1").GetComponent<GroundController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-6, 3);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.left*-groundspeed.groundSpeed*Time.deltaTime);
    }
}
