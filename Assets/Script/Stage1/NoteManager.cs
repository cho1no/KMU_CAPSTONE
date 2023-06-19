using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public enum State { Normal, Fever }
    public State stageState;
    public SpeedData[] speedData;
    public int bpm = 0;
    [SerializeField] double currentTime;

    public int level;
    int num;
    [SerializeField] int  maxLevel;
    [SerializeField] Transform tfNoteApeear;
    [SerializeField] double feverTime;
    [SerializeField] float levelUpTimer;

    TimingManager timingManager;
    EffectManager effectManager;

    public GameObject[] buttons;
    public GameObject feverButton;
    public GameObject feverPanel;


    private void Awake()
    {
        timingManager = GetComponent<TimingManager>();
        effectManager = FindObjectOfType<EffectManager>();

    }
    private void Start()
    {
        stageState = State.Normal;
        maxLevel = 5;
    }

    private void Update()
    {
        levelUpTimer += Time.deltaTime;
        if (timingManager.currentCombo >= 30)
        {

            stageState = State.Fever;
        }
        if (levelUpTimer >= 10)
        {
            level++;
            levelUpTimer = 0;
        }
        else if (level == maxLevel)
        {
            level = maxLevel;
            levelUpTimer = 0;
        }
        switch (stageState)
        {

            case State.Normal:
                //bpm = 120;
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
                ButtonActive(true);
                feverPanel.SetActive(false);
                RandomGenerate();

                break;
            case State.Fever:
                //bpm = 180;
                currentTime += Time.deltaTime;
                feverTime += Time.deltaTime;
                feverPanel.SetActive(true);


                if (currentTime >= 60d / bpm)
                {
                    num = 3;
                    GameObject t_note = NotePool1.instance.Get(num);
                    t_note.GetComponent<NoteControl>().Init(speedData[level]);// �ð��� ���� ��Ʈ ���ǵ� ���
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
        if (collision.gameObject.layer == 10)
        {
            if (collision.GetComponent<NoteControl>().GetNoteFlag())
            {
                effectManager.judgeMentEffect(4);
                timingManager.boxNoteList.Remove(collision.gameObject);

                collision.GetComponent<NoteControl>().HideNote();
                HpManager.instance.SetHp(-1);
                Handheld.Vibrate();
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
        int randomNote = Random.Range(0, 100);
        Debug.Log(num);

        if (randomNote <= 24)
        {
            num = 0;
        }
        else if (randomNote <= 67)
        {
            num = 1;
        }
        else if (randomNote <= 100)
        {
            num = 2;
        }
    }
}
[System.Serializable]
public class SpeedData
{
    public int noteSpeed;
    public int bpm;
}

