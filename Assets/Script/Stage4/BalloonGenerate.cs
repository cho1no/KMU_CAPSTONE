using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGenerate : MonoBehaviour
{
    float spawnMaxTime = 4f;
    float spawnTime, levelTime;
    public Transform[] spawnPoint;

    public Level[] level;
    
    int curlevel, maxLevel = 5;
    ButtonControl buttonControl;
    private void Awake()
    {
        buttonControl = FindObjectOfType<ButtonControl>();
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        
        spawnTime += Time.deltaTime;
        levelTime += Time.deltaTime;
        Init(level[curlevel]);
        if (spawnTime >= spawnMaxTime)
        {
            Spawn();
            spawnTime = 0;
        }

        if (levelTime >= 30)
        {
            curlevel++;
            levelTime = 0;
        }
        if (curlevel >= maxLevel)
        {
            curlevel = maxLevel;
        }
    }
    void Init(Level level)
    {
        spawnMaxTime = level.spawnMaxTime;
    }
    public void Spawn()
    {
        GameObject balloon = BalloonPool.instance.Get(0);
        int point = Random.Range(1, spawnPoint.Length);
        balloon.transform.position = spawnPoint[point].position;
        if (point == 1)
        {
            balloon.tag = "Section1";
            buttonControl.balloonList1.Add(balloon);
        }
        else if (point == 2)
        {
            balloon.tag = "Section2";
            buttonControl.balloonList2.Add(balloon);
        }
        else if (point == 3)
        {
            balloon.tag = "Section3";
            buttonControl.balloonList3.Add(balloon);
        }
    }
}
[System.Serializable]
public class Level
{
    public float spawnMaxTime;
}
