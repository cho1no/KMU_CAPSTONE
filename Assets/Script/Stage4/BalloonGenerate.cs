using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGenerate : MonoBehaviour
{
    [SerializeField]float spawnTime, levelTime, spawnMaxTime = 4f;
    public Transform[] spawnPoint;

    public Level[] level;
    
    [SerializeField]int curlevel, maxLevel = 5;
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
        int balloonCount = Random.Range(0, 5);
        GameObject balloon = BalloonPool.instance.Get(balloonCount);
        //balloon = balloon.transform.GetChild(0).gameObject;
        int point = Random.Range(1, spawnPoint.Length);
        balloon.transform.position = spawnPoint[point].position;
        if (point == 1)
        {
            balloon.transform.GetChild(0).tag = "Section1";
            buttonControl.balloonList1.Add(balloon);
        }
        else if (point == 2)
        {
            balloon.transform.GetChild(0).tag = "Section2";
            buttonControl.balloonList2.Add(balloon);
        }
        else if (point == 3)
        {
            balloon.transform.GetChild(0).tag = "Section3";
            buttonControl.balloonList3.Add(balloon);
        }
    }
}
[System.Serializable]
public class Level
{
    public float spawnMaxTime;
}
