using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPattern : MonoBehaviour
{
    public GroundController[] groundController;

    void Update()
    {

            SameGroundPattern();
    }
    void SameGroundPattern()
    {
        if (groundController[0].groundList[groundController[0].groundList.Count - 1].tag != "Ground" &&
            groundController[1].groundList[groundController[1].groundList.Count - 1].tag != "Ground" &&
            groundController[2].groundList[groundController[2].groundList.Count - 1].tag != "Ground")
        {
            Debug.Log("All Not ZERO!!");
            int random = Random.Range(0, 3);
            ChangeGround(random);
        }
    }
    void ChangeGround(int a)
    {
        Destroy(groundController[a].groundList[groundController[a].groundList.Count - 1]);
        groundController[a].groundList.Remove(groundController[a].groundList[groundController[a].groundList.Count - 1]);
        groundController[a].SpawnGround(0);
    }
}
