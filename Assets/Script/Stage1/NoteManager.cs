using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime;

    int num;
    [SerializeField] Transform tfNoteApeear;

    TimingManager timingManager;
    EffectManager effectManager;

    private void Awake()
    {
         timingManager = GetComponent<TimingManager>();
         effectManager = FindObjectOfType<EffectManager>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
       
        if (currentTime >= 60d/ bpm)
        {
            int randomNote = Random.Range(0, 100); // 확률 넣기
                                                   // Debug.Log(randomNote);
            Debug.Log(num);

            if (randomNote <= 29)
            {
                num = 0;
            }
            else if (randomNote <= 57)
            {
                num = 1;
            }
            else if (randomNote <= 85)
            {
                num = 2;
            }
            else if (randomNote <= 9)
            {
                num = 3;
            }
            else if (randomNote <= 95)
            {
                num = 4;
            }
            else if (randomNote <= 100)
            {
                num = 5;
            }

            GameObject t_note = NotePool1.instance.Get(num);
            t_note.transform.position = tfNoteApeear.position;
            t_note.transform.SetParent(transform);
            t_note.SetActive(true);

            timingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) //지나가는거
        {
            if (collision.GetComponent<NoteControl>().GetNoteFlag())
            {
                effectManager.judgeMentEffect(4);
                timingManager.boxNoteList.Remove(collision.gameObject);

                //NotePool.instance.noteQue.Enqueue(collision.gameObject);
                collision.GetComponent<NoteControl>().HideNote();
                HpManager.instance.SetHp(-1);
            }
            
        }
    }
}
