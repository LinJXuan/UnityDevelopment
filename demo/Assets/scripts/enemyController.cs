﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    //属性
    public GameObject player;
    public float speed;
    public float attackRange;
    public float timeAttack = 5f;
    private int Hp;
    public int attack;
    private bool isDead=false;

    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    public Slider enemyBlood;
    //积分
    private Statistic s;
    void Start()
    {
        s = Statistic.getInstance();
        rbody = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("RPG-Character").GetComponent<PlayerHealth>();
        player = GameObject.Find("RPG-Character");
        switch(transform.name[0]){
            case 'N':
            normal=NormalEnemy.getInstance();
            attackRange=normal.getRange();
            attack=normal.getAttack();
            Hp=normal.getHp();
            speed=1;
            break;
            case 'E':
            expert=ExpertEnemy.getInstance();
            attackRange=expert.getRange();
            attack=expert.getAttack();
            Hp=expert.getHp();
            speed=2;
            break;
            case 'B':
            boss=BossEnemy.getInstance();
            attackRange=boss.getRange();
            attack=boss.getAttack();
            Hp=boss.getHp();
            speed=1;
            break;
        }
        enemyBlood.value=Hp;
        enemyBlood.maxValue = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + 3f , transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value=Hp;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
            //transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime); 
            
            if (time >= timeAttack)
            {
               
                float dx = Mathf.Abs(player.transform.localPosition.x - transform.localPosition.x);
                if (dx < attackRange)
                {
                    Attack();
                }
            }
        }
    }

    public void Attack()
    {
        time = 0;
        playerHealth.TakeDamage(attack);
    }

        public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
       
        Hp -= damage;
        
        if (Hp <= 0)
        {
            Death();
            return;
        }
        print("enemyHp ===>" + Hp);
    }

    
    private void Death()
    {
        isDead = true;
        //设置获得积分
        s.setPoint(10); 
        Destroy(gameObject); 
    }

}
