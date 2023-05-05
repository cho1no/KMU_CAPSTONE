using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] itemParticle;
    [SerializeField] float liveTime;
    [SerializeField] int score, particleNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemWeapon"))
        {
            Destroy(gameObject);
            Score.instance.GetScore(score);
            //Instantiate(itemParticle[particleNum], transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        liveTime += Time.deltaTime;
        if (liveTime > 7.5f)
        {
            Destroy(gameObject);
        }
    }
}
