using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider enemyBlood;
    private void Awake()
    {
        enemy = new Enemy();
        s = Statistic.getInstance();
        enemyBlood.value=enemyHp;
        //enemyHp = enemy.getHp();
        //enemyShield = enemy.getShield();
        //enemyDefense = enemy.getDefense();
        //enemyAttack = enemy.getAttack();
        //enemyAttackRange = enemy.getRange();
        enemyDefense = Random.Range(10, 20);
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        //根据怪物防御力 计算不同的伤害
        enemyHp -= (damage - enemyDefense);
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
        //设置获得积分
        s.setPoint(10); 
        Destroy(gameObject); 
    }
    void Update(){
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + 3f , transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value=enemyHp;
    }
}