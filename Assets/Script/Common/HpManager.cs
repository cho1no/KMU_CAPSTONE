using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpManager : MonoBehaviour
{
    public static HpManager instance;
    public Animator ani;
    //������� ��Ʈ UI�� ��Ƴ��� ����ü
    public Image[] Heart;
    public GameObject gameOver;
    //�д°� ����, ���� �� private�� ǥ���Ѵ�.
    public int Hp { get; private set; }

    //Hp�� �ִ�ġ ����
    private int Hp_Max;

    //�տ� �׷��� �Ͱ� �ڿ� �׷��� ��
    public Sprite Back, Front;

    private void Update()
    {
        GameOver();
    }
    private void Awake()
    {
        instance = this;   
        //Hp_Max�� ����� ����
        Hp_Max = Heart.Length;

        //Hp �ʱ�ȭ.
        Hp = Hp_Max;

        //Front �̹��� �ʱ�ȭ
        for (int i = 0; i < Hp_Max; i++)
            if (Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }

    public void SetHp(int val)
    {
        //Hp ����
        Hp += val;

        //Hp�� 0������ �������� 0���� �����ϰ�, Hp_Max�� �ʰ��Ϸ��� �ϸ� Hp_Max�� ������.
        Hp = Mathf.Clamp(Hp, 0, Hp_Max);

        //Front �̹��� ��� ����
        for (int i = 0; i < Hp_Max; i++)
            Heart[i].sprite = Back;

        //Front �̹��� �׸���
        for (int i = 0; i < Hp_Max; i++)
            if (Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }

    public void GameOver()
    {
        if (Hp == 0)
        {
            
            Invoke("Stop",1f);
            ani.SetTrigger("GameOver");
            //gameOver.SetActive(true);
        }
    }
    //IEnumerator GameOverRoutine()
    //{
    //    gameOver.SetActive(true);
    //    ani.SetTrigger("GameOver");
    //    yield return new WaitForSeconds(0.5f);
    //    Stop();
    //}
    void Stop()
    {
        Time.timeScale = 0;
    }
}
