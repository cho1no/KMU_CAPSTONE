using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : MonoBehaviour
{
    public Scanner scanner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item1") && GameManager5.instance.weapon.count < 6)
        {
                GameManager5.instance.weapon.count++;
                GameManager5.instance.weapon.prefabId = 8;
                Debug.Log("¾ÆÀÌÅÛ È¹µæ0");
        }
        if (collision.gameObject.tag.Equals("Item2") && GameManager5.instance.weapon.count < 6)
        {
            GameManager5.instance.weapon.count++;
            GameManager5.instance.weapon.prefabId = 9;
            Debug.Log("¾ÆÀÌÅÛ È¹µæ1");
        }
        if (collision.gameObject.tag.Equals("Item3") && GameManager5.instance.weapon.count < 6)
        {
            GameManager5.instance.weapon.count++;
            GameManager5.instance.weapon.prefabId = 10;
            Debug.Log("¾ÆÀÌÅÛ È¹µæ1");
        }
    }

}
