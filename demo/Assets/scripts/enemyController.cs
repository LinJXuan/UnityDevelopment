using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {
    //属性
    public GameObject player;
    public float speed;
    public float attackRange;
    public float timeAttack = 5f;
    private int Hp;
    public int attack;
    private bool isDead = false;
    public int levelPoint; //升级点数

    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    public Slider enemyBlood;
    //积分
    private Statistic s;

    private bool look = false;
    private Vector3 position;
    void Start () {
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
                speed = normal.getSpeed ();
                break;
            case 'B':
                boss = BossEnemy.getInstance ();
                attackRange = boss.getRange ();
                attack = boss.getAttack ();
                Hp = boss.getHp ();
                speed = normal.getSpeed ();
                break;
        }
        enemyBlood.value = Hp;
        enemyBlood.maxValue = Hp;
        transform.LookAt (player.transform);
        position = transform.position;
    }

    // Update is called once per frame
    void Update () {
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3 (screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value = Hp;
    }

    private void FixedUpdate () {
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
        if (transform.name[0] == 'B') {
            boss.setcurrentHp (Hp);
        }

        if (Hp <= 0) {
            Death ();
            return;
        }
        print ("enemyHp ===>" + Hp);
    }

    public void AddlevelPoint () { //掉落升级点数
        //随机数
        float temp = Time.time;
        temp *= 1000;
        int tim = (int)temp;
        int rand = tim % 100;

        if (player.transform.name == "normal") {
            if (rand < 30) {//随机数小于30时掉落，即概率为30%
                PlusAttribute.playerLevelPoint += 1;
            }
        }
        if(player.transform.name == "expert"){
            if(rand < 50){
                PlusAttribute.playerLevelPoint += 1;
            }
        }
        if(player.transform.name == "boss"){
            PlusAttribute.playerLevelPoint += 1;
        }
    }
    private void Death () {
        isDead = true;
        AddlevelPoint();//掉落升级点数
        PlusAttribute.setAll();//写入属性
        //设置获得积分
        s.setPoint (10);
        Destroy (gameObject);
    }

}