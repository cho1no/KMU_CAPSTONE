using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn5 : MonoBehaviour
{

    public Boss boss;
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    [Header("레벨")]
    [SerializeField] int level, maxLevel = 4;
    [Header("카운트")]
    [SerializeField] float levelTimer, timer;
    public int bossCount, count, maxCount = 10;

    public poolManager pool;





    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        levelTimer += Time.deltaTime;
        if (timer > spawnData[level].spawnTime)
        {
            Spawn();
            timer = 0;
        }

        if (levelTimer >= 30)
        {
            level++;
            levelTimer = 0;
        }
        else if (level == maxLevel)
        {
            level = maxLevel;
            levelTimer = 0;
        }
        if (count == maxCount)
        {
            boss.BossSpawn(bossCount++);
            count = 0;
            if (bossCount >1)
            {
                bossCount = 0;
            }
        }
    }
    void Spawn()
    {
        int RandomSpawn = Random.Range(0, pool.prefabs.Length - 6); //랜덤 스폰
        GameObject enemy = GameManager5.instance.pool.Get(RandomSpawn);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
        count++;
    }
}
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public float shootInterval;
    public int health;
    public float speed;

}
