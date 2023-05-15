using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator;
    [SerializeField] Animator judgementAnimator;

    [SerializeField] Sprite[] judgeMentSprite;
    [SerializeField] UnityEngine.UI.Image judgeMentImage;
    string hit = "Hit";

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
    public void judgeMentEffect(int p_num)
    {
        judgeMentImage.sprite = judgeMentSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }
}
