using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public enum State { Normal, Fever}
    public State stageState;

    public int bpm = 0;
    double currentTime;
    
  
    int num;
    [SerializeField] Transform tfNoteApeear;

    TimingManager timingManager;
    EffectManager effectManager;

    public GameObject[] buttons;
    public GameObject feverButton;
    [SerializeField]double feverTime;
    public GameObject feverPanel; //버튼 이펙트, 판


    private void Awake()
    {
         timingManager = GetComponent<TimingManager>();
         effectManager = FindObjectOfType<EffectManager>();


    }
    private void Start()
    {
        stageState = State.Normal;
    }

    private void Update()
    {

        if (timingManager.currentCombo >= 50)
        {

            stageState = State.Fever;
        }
        switch (stageState)
        {
            
            case State.Normal:
                bpm = 120;
                currentTime += Time.deltaTime;
                if (currentTime >= 60d / bpm)
                {
                    RandomGenerate();
                    GameObject t_note = NotePool1.instance.Get(num);
                    t_note.transform.position = tfNoteApeear.position;
                    t_note.transform.SetParent(transform);
                    t_note.SetActive(true);

                    timingManager.boxNoteList.Add(t_note);
                    currentTime -= 60d / bpm;
                }

                ButtonActive(true); //3개버튼
                feverPanel.SetActive(false);
                RandomGenerate();

                break;
            case State.Fever:
                bpm = 180;
                currentTime += Time.deltaTime;
                feverTime += Time.deltaTime;
                feverPanel.SetActive(true);


                if (currentTime >= 60d / bpm)
                {
                    num = 6;
                    GameObject t_note = NotePool1.instance.Get(num);
                    t_note.transform.position = tfNoteApeear.position;
                    t_note.transform.SetParent(transform);
                    t_note.SetActive(true);

                    timingManager.boxNoteList.Add(t_note);
                    currentTime -= 60d / bpm;
                }

                ButtonActive(false);

                if (feverTime >= 10)
                {
                    stageState = State.Normal;
                    timingManager.ResetCombo();

                    feverTime = 0;
                }

                break;
            default:
                break;
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

                collision.GetComponent<NoteControl>().HideNote();
                HpManager.instance.SetHp(-1);
            }
        }
    }
    void ButtonActive(bool active)
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(active);
        }
        feverButton.SetActive(!active);
    }
    public void RandomGenerate()
    {
        int randomNote = Random.Range(0, 100); // 확률 넣기
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
    }

}
