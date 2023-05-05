using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimation playerani;
    public WeaponAnimation weaponani;
    public PlayerRotation playerRoation;
    public GameObject groundAttack;
    public GameObject skyAttack;
    public GameObject player;
    public int attackChance = 1;
    public float attackDelay;
    public void GroundAttack()
    {
        if (attackChance == 1)
        {
            if (playerRoation.speed > 0)
            {
                Instantiate(groundAttack, new Vector3(player.transform.position.x - 1, player.transform.position.y, 0), Quaternion.identity);
                attackChance--;
                //애니메이션
                playerani.sideattack();
                weaponani.sideattack();
            }
            else
            {
                Instantiate(groundAttack, new Vector3(player.transform.position.x + 1, player.transform.position.y, 0), Quaternion.identity);
                attackChance--;
                //애니메이션
                playerani.sideattack();
                weaponani.sideattack();
            }
        }
    }
    public void SkyAttack()
    {
        if (attackChance == 1)
        {
            if (playerRoation.speed > 0)
            {
                Instantiate(skyAttack, new Vector3(player.transform.position.x - 0.5f, player.transform.position.y + 1.3f, 0), Quaternion.identity);
                attackChance--;
                playerani.upattack();
                weaponani.upattack();
            }
            else
            {
                Instantiate(skyAttack, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 1.3f, 0), Quaternion.identity);
                attackChance--;
                playerani.upattack();
                weaponani.upattack();
            }
        }
    }
    private void Update()
    {
        if(attackChance == 0)
        {
            attackDelay += Time.deltaTime;
        }
        if (attackDelay > 0.5)
        {
            attackChance++;
            attackDelay = 0;
        }
    }
}
