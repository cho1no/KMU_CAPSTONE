using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour // ¹ÚÁã¶û µû·Î µÖ¾ßÇÒµí
{
    public Transform[] spawnPoint;
    public Transform[] spawnPointBat;
    public float batTimer;
    float timer;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {

            timer += Time.deltaTime;
            batTimer += Time.deltaTime;
            if (timer > 1.5f)
            {
                Spawn();
                timer = 0;
            }
            if (batTimer > 10f)
            {
                SpawnBat();
                batTimer = 0;
            }

    }
    void Spawn()
    {
        GameObject enemy = GameManager3.instance.pool.Get(Random.Range(0, 3));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
       
    }
    void SpawnBat()
    {
        GameObject enemy1 = GameManager3.instance.pool.Get(3);
        enemy1.transform.position = spawnPointBat[Random.Range(0, spawnPointBat.Length)].position;
    }
}

