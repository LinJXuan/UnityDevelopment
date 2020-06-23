﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {
    //属性
    private GameObject player;
    public float speed;
    public float attackRange;
    public float timeAttack = 5f;
    private int Hp;
    public int attack;
    private bool isDead = false;
    public Player p; //
    public int levelPoint; //升级点数

    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    public Slider enemyBlood;
    public GameObject flaptext;
    public Text flapword;
    public  GameObject weaponSword;
    public  GameObject weaponMetal;
    public  GameObject weaponSpear;

    //积分
    private Statistic s;

    private bool look = false;


    void Start () {
        flaptext=GameObject.Find("FlapWord");
        flaptext.SetActive(false);
        p = Player.getInstance ();
        levelPoint = p.getlevelPoint (); //获取当前升级点数
        s = Statistic.getInstance ();
        rbody = GetComponent<Rigidbody> ();
        playerHealth = GameObject.Find ("RPG-Character").GetComponent<PlayerHealth> ();
        player = GameObject.Find ("RPG-Character");
        switch (transform.name[0]) {
            case 'N':
                normal = NormalEnemy.getInstance ();
                attackRange = normal.getRange ();
                attack = normal.getAttack ();
                Hp = normal.getHp ();
                speed = normal.getSpeed ();
                break;
            case 'E':
                expert = ExpertEnemy.getInstance ();
                attackRange = expert.getRange ();
                attack = expert.getAttack ();
                Hp = expert.getHp ();
                speed = expert.getSpeed ();
                break;
            case 'B':
                boss = BossEnemy.getInstance ();
                attackRange = boss.getRange ();
                attack = p.getAttack ()*3;
                Hp =p.getHp()*10;
                speed = boss.getSpeed ();
                break;
        }
        enemyBlood.value = Hp;
        enemyBlood.maxValue = Hp;
    }

    // Update is called once per frame
    void Update () {
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3 (screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value = Hp;
        //伤害飘字的位置
        flapword.transform.position=new Vector3(screenPos.x, screenPos.y+80f, screenPos.z);
    }

    private void FixedUpdate () {
        //追踪玩家
        transform.LookAt(player.transform);

        time += Time.deltaTime;
        if (player != null) {
            if (time >= timeAttack) {
                float dx = Mathf.Abs (player.transform.localPosition.x - transform.localPosition.x);
                if (dx <= attackRange) {
                    look = true;
                    Attack ();
                }
            }
        }
    }

    public void Attack () {
        time = 0;
        playerHealth.TakeDamage (attack);
    }
    
    public void TakeDamage (int damage) {
        if (isDead) {
            return;
        }
        Hp -= damage;
        flapword.text="-"+damage;
        if (flaptext != null)
        {
            flaptext.SetActive(true);     //显示伤害
        }
        FlyTo(flapword);
        if (transform.name[0] == 'B') {
            boss.setcurrentHp (Hp);
        }

        if (Hp <= 0) {
            Death ();
            return;
        }
        print ("enemyHp ===>" + Hp);
    }

    private void AddlevelPoint () {
        //随机数
        float temp = Time.time;
        temp *= 1000;
        int tim = (int) temp;
        int rand = tim % 100;

        levelPoint = p.getlevelPoint ();
        if (transform.name[0] == 'N') {
            if (rand < 30) {
                levelPoint += 1;
                print ("升级点数+1");
            }
        }
        else if (transform.name[0] == 'E') {
            if (rand < 50) {
                levelPoint += 1;
                print ("升级点数+1");
            }
        }
        else if (transform.name[0] == 'B') {
            levelPoint += 1;
            print ("升级点数+1");

        }
    }
    private void Death () {
        isDead = true;
        AddlevelPoint ();
        p.setlevelPoint (levelPoint); //写入升级点数
        //设置获得积分
        s.setPoint (s.getPoint()+10);
        Destroy (gameObject);
        //武器掉落
        float temp = Time.time;
        temp *= 1000;
        int tim = (int)temp;
        int rand = tim % 100;
        if(rand<30) //随机数小于30时掉落，即概率为30% 掉落武器1
        {
        weaponSword=GameObject.Instantiate(weaponSword,new Vector3 (transform.position.x, transform.position.y+1f, transform.position.z),Quaternion.identity) as GameObject;
        }else{
            if(rand>=30&&rand<60)//掉落武器2
            {
                weaponMetal=GameObject.Instantiate(weaponMetal,new Vector3 (transform.position.x, transform.position.y+1f, transform.position.z),Quaternion.identity) as GameObject;
            }
            else{
                if(rand>=60){ //掉落武器3

                    weaponSpear=GameObject.Instantiate(weaponSpear,new Vector3 (transform.position.x, transform.position.y+1f, transform.position.z),Quaternion.identity) as GameObject;
                }
            }
        }
    }
     //伤害飘字函数
    public static void FlyTo(Graphic graphic)
    {
	    RectTransform rt = graphic.rectTransform;
	    Color c = graphic.color;
	    c.a = 0;
	    graphic.color = c; 
	    Sequence mySequence = DOTween.Sequence();
	    Tweener move1 = rt.DOMoveY(rt.position.y + 50, 0.5f);
	    Tweener move2 = rt.DOMoveY(rt.position.y + 100, 0.5f);
	    Tweener alpha1 = graphic.DOColor(new Color(c.r, c.g, c.b, 1), 0.5f);
	    Tweener alpha2 = graphic.DOColor(new Color(c.r, c.g, c.b, 0), 0.5f);
	    mySequence.Append(move1);
	    mySequence.Join(alpha1);
	    // mySequence.AppendInterval(1);
	    mySequence.Append(move2);
	    mySequence.Join(alpha2); 
    }
}