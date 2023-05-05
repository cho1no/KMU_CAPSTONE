using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    public GameObject Shadow;
    GameObject shadow1;

    private float Dist;
    // Start is called before the first frame update
    void Start()
    {
        shadow1 = Instantiate(Shadow, new Vector3(0, 0, 0),Quaternion.identity);
        //shadow1.transform.SetParent(gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        shadow1.transform.position = new Vector3(gameObject.transform.position.x, -2, 0);
        Dist = Vector3.Distance(gameObject.transform.position, shadow1.transform.position);
        float scaleX = 0.7f - Dist;
        float scaleY = 0.15f - Dist / 5;
        if (scaleX <= 0.15f)
            scaleX = 0.15f;
        if (scaleY <= 0.03f)
            scaleY = 0.03f;
        shadow1.transform.localScale = new Vector3(scaleX,scaleY, 0);
        OnDestroy();
    }
    public void OnDestroy()
    {
        if (transform.position.y <= -10)
        {
            gameObject.SetActive(false);
        }
    }
}
