using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); // �����������ִ��� ��� ��Ʈ�� �� 

    public ComboText combotext;
    public ComboCount combocount;

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //���� ����
    Vector2[] timingBoxs = null; //���������� �ּҰ�x, �ִ밪y

    EffectManager effectManager;
    public Animator ani;

    public Button redButton, blueButton, yellowButton;
    bool redButtonPressed = false;
    bool blueButtonPressed = false;
    bool yellowButtonPressed = false;
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
        redButton.onClick.AddListener(RedButtonPressed);
        blueButton.onClick.AddListener(BlueButtonPressed);
        yellowButton.onClick.AddListener(YellowButtonPressed);
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
        ani.SetTrigger("isPicking");
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

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
        }

        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
    }
    public void BlueButton()
    {
        ani.SetTrigger("isPicking");
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

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
    }

    public void YellowButton()
    {
        ani.SetTrigger("isPicking");
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

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        combotext.combo = 0;
    }

    void RedButtonPressed()
    {
        redButtonPressed = true;
        CheckButtonRY();
        CheckButtonRB();
    }
    void BlueButtonPressed()
    {
        blueButtonPressed = true;
        CheckButtonBY();
        CheckButtonRB();
    }
    void YellowButtonPressed()
    {
        yellowButtonPressed = true;
        CheckButtonRY();
        CheckButtonBY();
    }
    void CheckButtonRY() //�� ��
    {
        ani.SetTrigger("isPicking");
        if (yellowButtonPressed && redButtonPressed) //����
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

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
        }
    }

    void CheckButtonRB() //����
    {
        ani.SetTrigger("isPicking");
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

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
        }
    }

    void CheckButtonBY() //����
    {
        ani.SetTrigger("isPicking");
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

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            combotext.combo = 0;
        }
    }
}
