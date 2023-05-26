using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); // �����������ִ��� ��� ��Ʈ�� �� 

    [SerializeField] GameObject ComboImage;
    [SerializeField] UnityEngine.UI.Text comboText;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //���� ����
    Vector2[] timingBoxs = null; //���������� �ּҰ�x, �ִ밪y

    EffectManager effectManager;

    public int currentCombo = 0;
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

        comboText.gameObject.SetActive(false);
        ComboImage.SetActive(false);
    }
    public void FeverButton()
    {

        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;
            if (boxNoteList[0].layer == 10)
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
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();
                        TotalSound.instance.CatchStar();
                        boxNoteList.RemoveAt(i);
                        TotalSound.instance.CatchStar();
                        effectManager.judgeMentEffect(y);
                        return;
                    }
                }
            }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        Handheld.Vibrate();
    }
    public void RedButton()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "RedNote" || boxNoteList[0].tag == "RainbowNote") //���� �ʿ�
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
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();
                        boxNoteList.RemoveAt(i);

                        TotalSound.instance.CatchStar();
                        effectManager.judgeMentEffect(y);

                        IncreaseCombo();

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
            else if (boxNoteList[0].tag == "YellowRedNote" || boxNoteList[0].tag == "RedBlueNote")
            {
                return;
            }
            else { ResetCombo(); }

        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        ResetCombo();
        Handheld.Vibrate();
    }
    public void BlueButton()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "BlueNote" || boxNoteList[0].tag == "RainbowNote") //���� �����ɷ� �ٲ����
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
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();

                        boxNoteList.RemoveAt(i);
                        TotalSound.instance.CatchStar();
                        effectManager.judgeMentEffect(y);

                        //IncreaseCombo();

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
            else if (boxNoteList[0].tag == "BlueYellowNote" || boxNoteList[0].tag == "RedBlueNote")
            {
                return;
            }
            else { ResetCombo(); }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        ResetCombo();
        Handheld.Vibrate();
    }

    public void YellowButton()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            if (boxNoteList[0].tag == "YellowNote" || boxNoteList[0].tag == "RainbowNote")
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
                        }
                        boxNoteList[i].GetComponent<NoteControl>().HideNote();
                        boxNoteList.RemoveAt(i);

                        TotalSound.instance.CatchStar();
                        effectManager.judgeMentEffect(y);
                        //IncreaseCombo();

                        redButtonPressed = false;
                        blueButtonPressed = false;
                        yellowButtonPressed = false;
                        return;
                    }
                }
            }
            else if (boxNoteList[0].tag == "YellowRedNote" || boxNoteList[0].tag == "BlueYellowNote")
            {
                return;
            }
            else { ResetCombo(); }
        }
        effectManager.judgeMentEffect(timingBoxs.Length); //Miss
        ResetCombo();
        Handheld.Vibrate();
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
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            TotalSound.instance.CatchStar();
                            effectManager.judgeMentEffect(y);
                            //IncreaseCombo(); //�۵� �ȵǴ� ��

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            ResetCombo();
            Handheld.Vibrate();
        }
    }

    void CheckButtonRB() //����
    {
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
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            TotalSound.instance.CatchStar();
                            effectManager.judgeMentEffect(y);
                            //IncreaseCombo();

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            ResetCombo();
            Handheld.Vibrate();
        }
    }

    void CheckButtonBY() //����
    {
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
                            }
                            boxNoteList[i].GetComponent<NoteControl>().HideNote();
                            boxNoteList.RemoveAt(i);

                            TotalSound.instance.CatchStar();
                            effectManager.judgeMentEffect(y);
                            //IncreaseCombo();

                            redButtonPressed = false;
                            blueButtonPressed = false;
                            yellowButtonPressed = false;
                            return;
                        }
                    }
                }
            }
            effectManager.judgeMentEffect(timingBoxs.Length); //Miss
            ResetCombo();
            Handheld.Vibrate();
        }
    }
    public void IncreaseCombo(int num = 1)
    {
        currentCombo += num;
        comboText.text = string.Format("{0:#,##0}", currentCombo);

        if (currentCombo > 2)
        {
            comboText.gameObject.SetActive(true);
            ComboImage.SetActive(true);
        }
        GetCombo();
    }
    public void ResetCombo()
    {
        currentCombo = 0;
        comboText.text = "0";
        comboText.gameObject.SetActive(false);
        ComboImage.SetActive(false);
    }
    int GetCombo()
    {
        return currentCombo;
    }

}
