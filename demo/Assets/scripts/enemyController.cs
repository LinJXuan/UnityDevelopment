using DG.Tweening;
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
    //积分
    private Statistic s;

    private bool look = false;
    private Vector3 position;

    //飘血
    public static GameObject flaptext;
    public Text flapWord;

    void Start () {
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
                attack = boss.getAttack ();
                Hp = boss.getHp ();
                speed = boss.getSpeed ();
                break;
        }
        enemyBlood.value = Hp;
        enemyBlood.maxValue = Hp;
        transform.LookAt (player.transform);
        position = transform.position;

        //飘血
        flaptext = GameObject.Find("flapWord");
        flaptext.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3 (screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value = Hp;
        //伤害飘字的位置
        //有问题
        flapWord.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 50f, transform.localPosition.z);
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
        if (flaptext != null)
        {
            flaptext.SetActive(true);     //显示伤害
            FlyTo(flapWord);
        }

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
        s.setPoint (10);
        Destroy (gameObject);
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