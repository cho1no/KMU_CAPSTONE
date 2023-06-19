using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonpop : MonoBehaviour
{
    public static ballonpop instance;
    AudioSource audioSource;
    public AudioClip stage4ballonpop;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ballonpopp()
    {
        audioSource.clip = stage4ballonpop;
        audioSource.Play();
    }
}
