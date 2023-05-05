using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
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
    private void Update()
    {
        OnDestroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "attack")
        {
            if (playerRotation.speed > 0)
            {
                Vector3 speed1 = new Vector3(-300, 950, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            else
            {
                Vector3 speed1 = new Vector3(300, 950, 0);
                GetComponent<Rigidbody2D>().AddForce(speed1);
            }
            combotext.combo++;
            combotext.Ani();
            combocount.Ani();
            Score.instance.GetScore(100);
            hitSound.Play();
        }
    }
    public void OnDestroy()
    {
        if (transform.position.y >= 13)
        {
            gameObject.SetActive(false);
        }
    }
}
