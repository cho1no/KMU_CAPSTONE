using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] bossPrefab;
    public GameObject spawner;


    private void Update()
    {
   
    }
    public void BossSpawn(int bosscount)
    {
        int bossRandomSpawn = Random.Range(0, bossPrefab.Length);
        Instantiate(bossPrefab[bossRandomSpawn], transform.position, Quaternion.identity);
        TotalSound.instance.Stage5BossAppear();
        Debug.Log("보스 등장");
        spawner.SetActive(false);
    }
}
