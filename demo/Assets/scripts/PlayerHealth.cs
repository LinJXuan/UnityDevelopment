using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHp;
    public int playerDefense;
    //public int playerAttackRange;
    public int playerAttack;
    public static int numberOfEnemy; //怪物计数，用来计算升级点数
    private Player p;
    private RpgScript player;

    private void Awake()
    {
        p = Player.getInstance();
        player = GameObject.Find("RPG-Character").GetComponent<RpgScript>();
        p.reloadcurrentHp();
        playerHp = p.getcurrentHp();
        playerDefense = p.getDefense();
        playerAttack = p.getAttack();
        player.setMaxHpUi(p.getHp());
        numberOfEnemy = 0;
        //playerAttackRange = p.getRange();
    }
    void Update(){
        player.setMaxHpUi(p.getHp());
        playerHp = p.getcurrentHp();
        playerDefense = p.getDefense();
        playerAttack = p.getAttack();
    }

    public void TakeDamage(int damage)
    {
        playerHp = p.getcurrentHp();
        //计算最终伤害
        playerHp -= (damage - playerDefense);
        p.setcurrentHp(playerHp);

        if (playerHp <= 0)
        {
            playerHp = 0;
            p.setcurrentHp(playerHp);
            player.setState(-3);
            player.playerIsAlive(false);
            return;
        }
        print("playerHp ===>" + playerHp);
    }
}
