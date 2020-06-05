using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHp;
    public int playerShield;
    public int playerDefense;
    public int playerAttackRange;
    public int playerAttack;
    private Player p;
    private RpgScript player;

    private void Awake()
    {
        p = Player.getInstance();
        player = GameObject.Find("RPG-Character").GetComponent<RpgScript>();

        playerHp = p.getcurrentHp();
        playerShield = p.getShield();
        playerDefense = p.getDefense();
        playerAttack = p.getAttack();
        playerAttackRange = p.getRange();
    }

    public void TakeDamage(int damage)
    {
        playerHp -= damage;
        //p.setcurrentHp(playerHp);
        if (playerHp <= 0)
        {
            playerHp = 0;
            player.setState(-3);
            player.playerIsAlive(false);
            return;
        }
        print("playerHp ===>" + playerHp);
    }
}
