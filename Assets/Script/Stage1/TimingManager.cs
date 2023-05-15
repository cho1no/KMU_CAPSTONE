using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); // 판정범위에있는지 모든 노트를 비교 

    public ComboText combotext;
    public ComboCount combocount;

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //판정 범위
    Vector2[] timingBoxs = null; //판정범위의 최소값x, 최대값y

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
        //박스 타이밍 설정
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2,
                              Center.localPosition.y + timingRect[i].rect.height / 2); // 최소값 = 중심 - (이미지높이/2), 최대값 = 중심 + (이미지높이/2)
        }
    }
    private void Update() // 혼합별 버튼동시에 사용
    {
        if (redButtonPressed && yellowButtonPressed) //빨노
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
                            if (y == 0) //퍼펙트
                                Score.instance.GetScore(70);
                            else if (y == 1) //쿨
                                Score.instance.GetScore(50);
                            else if (y == 2) //굿
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
        if (redButtonPressed && blueButtonPressed) //빨파
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
                            if (y == 0) //퍼펙트
                                Score.instance.GetScore(70);
                            else if (y == 1) //쿨
                                Score.instance.GetScore(50);
                            else if (y == 2) //굿
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
        if (blueButtonPressed && yellowButtonPressed) //노파
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
                            if (y == 0) //퍼펙트
                                Score.instance.GetScore(70);
                            else if (y == 1) //쿨
                                Score.instance.GetScore(50);
                            else if (y == 2) //굿
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
                        if (y == 0) //퍼펙트
                            Score.instance.GetScore(70);
                        else if (y == 1) //쿨
                            Score.instance.GetScore(50);
                        else if (y == 2) //굿
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

            if (boxNoteList[0].tag == "BlueNote") //가장 가까운걸로 바꿔야함
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
