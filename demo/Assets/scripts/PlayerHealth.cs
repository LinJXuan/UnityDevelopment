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
    private RpgScript playerState;

    private void Awake()
    {
        playerState = GameObject.Find("RPG-Character").GetComponent<RpgScript>();

        playerHp = PlayerAttribute.currentHp;
        playerShield = PlayerAttribute.shield;
        playerDefense = PlayerAttribute.defense;
        playerAttack = PlayerAttribute.attack;
        playerAttackRange = PlayerAttribute.attackRange;
    }

    public void TakeDamage(int damage)
    {
        playerHp -= damage;
        if (playerHp > 0)
        {
            PlayerAttribute.currentHp = playerHp;
        }
        else
        {
            PlayerAttribute.currentHp = 0;
            playerHp = 0;
            playerState.setState(-3);
        }
        print("playerHp ===>" + playerHp);
    }
}
