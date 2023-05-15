using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public float noteSpeed = 400;
    public float sizeSpeed;
    public float alphaSpeed;
    public float maxSize = 3;
    UnityEngine.UI.Image noteImage;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        noteSpeed = 400;
        sizeSpeed = 0.75f;
        alphaSpeed = 0.2f;
    }
    private void OnEnable()
    {
        if (noteImage == null)
        {
            noteImage = GetComponent<UnityEngine.UI.Image>();
        }
        noteImage.enabled = true;
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
        Vector3 newSize = transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        newSize = Vector3.Min(newSize, Vector3.one * maxSize);
        rectTransform.localScale += Vector3.one * sizeSpeed * Time.deltaTime;

        Color color = noteImage.color;
        color.a += alphaSpeed * Time.deltaTime;
        noteImage.color = color;
    }
}