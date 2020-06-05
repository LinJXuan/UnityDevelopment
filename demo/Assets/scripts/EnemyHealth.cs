using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHp;
    public int enemyShield;
    public int enemyDefense;
    public int enemyAttackRange;
    public int enemyAttack;
    private Enemy enemy;
    private EnemyController targetEnemy;
    private bool isDead=false;
    //添加积分
    private Statistic s;
    private void Awake()
    {
        enemy = new Enemy();
        s = Statistic.getInstance();
        //enemyHp = enemy.getHp();
        //enemyShield = enemy.getShield();
        //enemyDefense = enemy.getDefense();
        //enemyAttack = enemy.getAttack();
        //enemyAttackRange = enemy.getRange();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        enemyHp -= damage;
        //p.setcurrentHp(playerHp);
        if (enemyHp <= 0)
        {
            Death();
            return;
        }
        print("enemyHp ===>" + enemyHp);
    }

    private void Death()
    {
        isDead = true;
        s.setPoint(10);
        Destroy(gameObject);
    }
}