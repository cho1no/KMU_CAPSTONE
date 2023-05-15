using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectInfo
{
    public GameObject[] goPrefab;
    public int count;
    public Transform tfPoolParent;
}
public class NotePool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo;

    public Queue<GameObject> noteQue = new Queue<GameObject>(); //선입선출
    public static NotePool instance;
    private void Start()
    {
        instance = this;
        noteQue = InsertQueue(objectInfo[0]);
        //noteQue = InsertQueue(objectInfo[1]);
        //noteQue = InsertQueue(objectInfo[2]);
    }
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.count; i++)
        {
            int RandomNote = Random.Range(0, p_objectInfo.goPrefab.Length);
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab[RandomNote], transform.position, Quaternion.identity);
            t_clone.SetActive(false);
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }

}
