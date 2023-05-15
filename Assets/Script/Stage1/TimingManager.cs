using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); // �����������ִ��� ��� ��Ʈ�� �� 

    public ComboText combotext;
    public ComboCount combocount;

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //���� ����
    Vector2[] timingBoxs = null; //���������� �ּҰ�x, �ִ밪y

    EffectManager effectManager;

    bool redButtonPressed;
    bool blueButtonPressed;
    bool yellowButtonPressed;
    private void Awake()
    {
        effectManager = FindObjectOfType<EffectManager>();
    }
    private void Start()
    {
        //�ڽ� Ÿ�̹� ����
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2,
                              Center.localPosition.y + timingRect[i].rect.height / 2); // �ּҰ� = �߽� - (�̹�������/2), �ִ밪 = �߽� + (�̹�������/2)
        }
    }
    private void Update() // ȥ�պ� ��ư���ÿ� ���
    {
        if (redButtonPressed && yellowButtonPressed) //����
        {
            for (int i = 0; i < boxNoteList.Count; i++)
            {
                float t_notePosY = boxNoteList[i].transform.localPosition.y;

                if (boxNoteList[0].tag == "YellowRedNote")
                {
                    for (int y = 0; y < timingBoxs.Length; y++)
                    {
                        if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                        {
                            if (y == 0) //����Ʈ
                                Score.instance.GetScore(70);
                            else if (y == 1) //��
                                Score.instance.GetScore(50);
                            else if (y == 2) //��
                                Score.instance.GetScore(30);
                            if (y < timingBoxs.Length - 1) // bad
                            {
                                effectManager.NoteHitEffect();
                                combotext.combo = 0;
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            effectManager.judgeMentEffect(y);

                            combotext.combo++;
                            combotext.Ani();
                            combocount.Ani();
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
            HpManager.instance.SetHp(-1);
        }
        if (redButtonPressed && blueButtonPressed) //����
        {
            for (int i = 0; i < boxNoteList.Count; i++)
            {
                float t_notePosY = boxNoteList[i].transform.localPosition.y;

                if (boxNoteList[0].tag == "RedBlueNote")
                {
                    for (int y = 0; y < timingBoxs.Length; y++)
                    {
                        if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                        {
                            if (y == 0) //����Ʈ
                                Score.instance.GetScore(70);
                            else if (y == 1) //��
                                Score.instance.GetScore(50);
                            else if (y == 2) //��
                                Score.instance.GetScore(30);
                            if (y < timingBoxs.Length - 1) // bad
                            {
                                effectManager.NoteHitEffect();
                                combotext.combo = 0;
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            effectManager.judgeMentEffect(y);

                            combotext.combo++;
                            combotext.Ani();
                            combocount.Ani();
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
            HpManager.instance.SetHp(-1);
        }
        if (blueButtonPressed && yellowButtonPressed) //����
        {
            for (int i = 0; i < boxNoteList.Count; i++)
            {
                float t_notePosY = boxNoteList[i].transform.localPosition.y;

                if (boxNoteList[0].tag == "BlueYellowNote")
                {
                    for (int y = 0; y < timingBoxs.Length; y++)
                    {
                        if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                        {
                            if (y == 0) //����Ʈ
                                Score.instance.GetScore(70);
                            else if (y == 1) //��
                                Score.instance.GetScore(50);
                            else if (y == 2) //��
                                Score.instance.GetScore(30);
                            if (y < timingBoxs.Length - 1) // bad
                            {
                                effectManager.NoteHitEffect();
                                combotext.combo = 0;
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            effectManager.judgeMentEffect(y);

                            combotext.combo++;
                            combotext.Ani();
                            combocount.Ani();
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
            HpManager.instance.SetHp(-1);
        }
    }
    //public void FeverButton()
    //{
    //    for (int i = 0; i < boxNoteList.Count; i++)
    //    {
    //        float t_notePosY = boxNoteList[i].transform.localPosition.y;
    //        if (boxNoteList[0].layer == 10)
    //        {
    //            for (int y = 0; y < timingBoxs.Length; y++)
    //            {
    //                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
    //                {
    //                    Destroy(boxNoteList[i]);
    //                    boxNoteList.RemoveAt(i);
    //                    Debug.Log("Hit" + y);
    //                    return;
    //                }
    //            }

    //        }
    //    }
    //    Debug.Log("Miss");
    //}
    public void RedButton()
    {
        redButtonPressed = true;
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "RedNote")
            {
                for (int y = 0; y < timingBoxs.Length; y++)
                {
                    if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                    {
                        if (y == 0) //����Ʈ
                            Score.instance.GetScore(70);
                        else if (y == 1) //��
                            Score.instance.GetScore(50);
                        else if (y == 2) //��
                            Score.instance.GetScore(30);
                        if (y < timingBoxs.Length - 1) // bad
                        {
                            effectManager.NoteHitEffect();
                            combotext.combo = 0;
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();
                        boxNoteList.RemoveAt(i);

                        effectManager.judgeMentEffect(y);

                        combotext.combo++;
                        combotext.Ani();
                        combocount.Ani();
                        return;
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
        HpManager.instance.SetHp(-1);
    }
    public void RedButtonReleased()
    {
        redButtonPressed = false;
    }
    public void BlueButton()
    {
        blueButtonPressed = true;
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "BlueNote") //���� �����ɷ� �ٲ����
            {
                for (int y = 0; y < timingBoxs.Length; y++)
                {
                    if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                    {
                        if (y == 0)
                            Score.instance.GetScore(70);
                        else if (y == 1)
                            Score.instance.GetScore(50);
                        else if (y == 2)
                            Score.instance.GetScore(30);
                        if (y < timingBoxs.Length - 1) // bad
                        {
                            effectManager.NoteHitEffect();
                            combotext.combo = 0;
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();

                        boxNoteList.RemoveAt(i);
                        effectManager.judgeMentEffect(y);

                        combotext.combo++;
                        combotext.Ani();
                        combocount.Ani();
                        return;
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
        HpManager.instance.SetHp(-1);
    }

    public void BlueButtonReleased()
    {
        blueButtonPressed = false;
    }
    public void YellowButton()
    {
        yellowButtonPressed = true;
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "YellowNote")
            {
                for (int y = 0; y < timingBoxs.Length; y++)
                {
                    if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                    {
                        if (y == 0)
                            Score.instance.GetScore(70);
                        else if (y == 1)
                            Score.instance.GetScore(50);
                        else if (y == 2)
                            Score.instance.GetScore(30);
                        if (y < timingBoxs.Length - 1) // bad
                        {
                            effectManager.NoteHitEffect();
                            combotext.combo = 0;
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();

                        boxNoteList.RemoveAt(i);
                        effectManager.judgeMentEffect(y);

                        combotext.combo++;
                        combotext.Ani();
                        combocount.Ani();
                        return;  
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
        HpManager.instance.SetHp(-1);
    }
    public void YellowButtonReleased()
    {
        yellowButtonPressed = false;
    }
}
