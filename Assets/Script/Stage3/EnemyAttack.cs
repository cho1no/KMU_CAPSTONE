using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public ComboText combotext;
    public ComboCount combocount;
    public AudioSource hitSound;
    public PlayerRotation playerRotation;

    private void Awake()
    {
        combotext = GameObject.Find("Combo").GetComponent<ComboText>();
        combocount = GameObject.Find("ComboCount").GetComponent<ComboCount>();
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        playerRotation = GameObject.Find("player").GetComponent<PlayerRotation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            if (playerRotation.speed > 0)
            {
                Vector3 speed1 = new Vector3(-500, 1000, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            else
            {
                Vector3 speed1 = new Vector3(500, 1000, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            combotext.combo++;
            combotext.Ani();
            combocount.Ani();
            Score.instance.GetScore(50);
            hitSound.Play();
        }
    }
}
