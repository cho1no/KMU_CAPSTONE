using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalSound : MonoBehaviour
{
    public static TotalSound  instance;
    AudioSource audioSource;
    [Header("Common")]
    public AudioClip buttonClick;
    public AudioClip buyGame;
    public AudioClip playerHit;
    public AudioClip getHpItem;
    [Header("Stage1")]
    public AudioClip stage1CatchStar;
    [Header("Stage3")]
    public AudioClip stage3WolfHit;
    [Header("Stage5")]
    public AudioClip stage5Boom;
    public AudioClip stage5BossAppear;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Common
    public void LobbyBtnClick()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }
    public void LobbyBuyGame()
    {
        audioSource.clip = buyGame;
        audioSource.Play();
    }
    public void PlayerHit()
    {
        audioSource.clip = playerHit;
        audioSource.Play();
    }
    public void GetHpItem()
    {
        audioSource.clip = getHpItem; audioSource.Play();
    }
    //Stage1
    public void CatchStar()
    {
        audioSource.clip = stage1CatchStar; audioSource.Play();
    }
    //Stage3
    public void WolfHit()
    {
        audioSource.clip = stage3WolfHit;
        audioSource.Play();
    }


    //Stage5
    public void Stage5BoomClick()
    {
        audioSource.clip = stage5Boom;
        audioSource.Play();
    }
    public void Stage5BossAppear()
    {
        audioSource.clip = stage5BossAppear;
        audioSource.Play();
    }
}
