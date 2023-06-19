using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public float noteSpeed;
    public float scaleSpeed;
    public float alphaSpeed;
    public float maxSize = 2;
    UnityEngine.UI.Image noteImage;
    [SerializeField] float speedUpTime;
    float initialWidth, initialHeight;

    RectTransform rectTransform;
    NoteManager noteManager;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        noteManager = FindObjectOfType<NoteManager>();
    }
    private void Start()
    {
        noteSpeed = 400;
        scaleSpeed = 0.5f;
        alphaSpeed = 0.2f;

        initialWidth = transform.localScale.x;
        initialHeight = transform.localScale.y;
    }
    private void OnEnable()
    {
        if (noteImage == null)
        {
            noteImage = GetComponent<UnityEngine.UI.Image>();
        }
        noteImage.enabled = true;

    }
    public void Init(SpeedData data)
    {
        noteSpeed = data.noteSpeed;
        noteManager.bpm = data.bpm;
    }
    public void HideNote()
    {
        noteImage.enabled = false;
        gameObject.SetActive(false);
        rectTransform.localScale = Vector3.one;
    }
    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
    private void Update()
    {
        Init(noteManager.speedData[noteManager.level]);
        Vector3 newSize = transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        newSize = Vector3.Min(newSize, Vector3.one * maxSize);

        // width와 height 증가
        float newWidth = transform.localScale.x + scaleSpeed * Time.deltaTime;
        float newHeight = transform.localScale.y + scaleSpeed * Time.deltaTime;

        // 이미지의 크기 제한 (원하는 최대 크기)
        float maxWidth = 2f;
        float maxHeight = 2f;

        // 크기가 제한을 초과하지 않도록 처리
        newWidth = Mathf.Clamp(newWidth, initialWidth, maxWidth);
        newHeight = Mathf.Clamp(newHeight, initialHeight, maxHeight);

        // 이미지의 크기 업데이트
        transform.localScale = new Vector3(newWidth, newHeight, 1);

        Color color = noteImage.color;
        color.a += alphaSpeed * Time.deltaTime;
        noteImage.color = color;
    }
}