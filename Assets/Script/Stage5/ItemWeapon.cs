using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : MonoBehaviour
{
    public Scanner scanner;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item1") && GameManager5.instance.weapon.count < 6)
        {
            GameManager5.instance.weapon.count++;
            GameManager5.instance.weapon.prefabId = 8;
            Debug.Log("������ ȹ��0");
            AudioSet();
        }
        if (collision.gameObject.tag.Equals("Item2") && GameManager5.instance.weapon.count < 6)
        {
            GameManager5.instance.weapon.count++;
            GameManager5.instance.weapon.prefabId = 9;
            Debug.Log("������ ȹ��1");
            AudioSet();
        }
        if (collision.gameObject.tag.Equals("Item3") && GameManager5.instance.weapon.count < 6)
        {
            GameManager5.instance.weapon.count++;
            GameManager5.instance.weapon.prefabId = 10;
            Debug.Log("������ ȹ��1");
            AudioSet();
        }
        if (collision.gameObject.tag.Equals("Item4"))
        {
            PlayerControl.instance.setBoom(+1);
            //PlayerControl.instance.boomImage[PlayerControl.instance.boomCount-1].transform.gameObject.SetActive(true);
            Debug.Log("������ ȹ��1");
            AudioSet();
        }
    }
    private void AudioSet()
    {
        audioSource.Play();
      
    }
}
