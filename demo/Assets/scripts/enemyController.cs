using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {
    private Animator anim;
    //属性
    private GameObject player;
    public float speed;
    public float attackRange;
    public float timeAttack = 5f;
    public int Hp;
    public int attack;
    private bool isDead = false;
    private Player p;


    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    public Slider enemyBlood;
    public GameObject flaptext;
    public Text flapword;
    public GameObject weaponAex;
    public GameObject weaponHammer;
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    private Vector3 deathPosition;
    //积分
    private Statistic s;

    private bool look = false;

    private BossMove bossmove;
    void Start () {
        anim = GetComponent<Animator> ();
        flaptext = GameObject.Find ("FlapWord");
        flaptext.SetActive (false);
        p = Player.getInstance ();
        s = Statistic.getInstance ();
        rbody = GetComponent<Rigidbody> ();
        player = GameObject.Find ("RPG-Character");
        playerHealth = player.GetComponent<PlayerHealth> ();
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
                boss.setcurrentHp (Hp);
                speed = boss.getSpeed ();
                break;
        }
        //enemyBlood=this.gameObject;
        enemyBlood.value = Hp;
        enemyBlood.maxValue = Hp;
    }

    // Update is called once per frame
    void Update () {
        Vector3 playerPosition = player.transform.position;
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //血条位置
        enemyBlood.transform.position = new Vector3 (screenPos.x, screenPos.y, screenPos.z);
        enemyBlood.value = Hp;
        //伤害飘字的位置
        flapword.transform.position = new Vector3 (screenPos.x, screenPos.y + 80f, screenPos.z);

    }

    private void FixedUpdate () {
        //追踪玩家
        if (!look) {
            transform.LookAt (player.transform);
        }

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
        anim.SetTrigger ("Attack");
        print ("攻击====>" + attack);
        playerHealth.TakeDamage (attack);
    }

    public void TakeDamage (int damage) {
        if (isDead) {
            return;
        }
        anim.SetTrigger ("Gethit");
        Hp -= damage;
        if (transform.name[0] == 'B') {
            boss.setcurrentHp (Hp);
        }
        flapword.text = "-" + damage;
        if (flaptext != null) {
            flaptext.SetActive (true); //显示伤害
        }
        FlyTo (flapword);
        if (transform.name[0] == 'B') {
            boss.setcurrentHp (Hp);
        }

        if (Hp <= 0) {
            Death ();
            return;
        }
        print ("enemyHp ===>" + Hp);
    }

    private void Death () {
        deathPosition = transform.position;
        player.GetComponent<RpgScript> ().enemyDeathPosition = transform.position;
        isDead = true;
        anim.SetBool ("Die", true);

        //设置获得积分
        s.setPoint (s.getPoint () + 10);
        Destroy (gameObject);
        //武器掉落
        float temp = Time.time;
        temp *= 1000;
        int tim = (int) temp;
        int rand = tim % 100;
        if (rand < 10) //10%概率掉落武器斧头
        {
            weaponAex = GameObject.Instantiate (weaponAex, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity) as GameObject;
            player.GetComponent<RpgScript> ().dropWeaponAex = true;
        }
        if(rand >= 10&&rand<20){ //10%概率掉落武器大锤
            weaponHammer = GameObject.Instantiate (weaponHammer, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity) as GameObject;
            player.GetComponent<RpgScript> ().dropWeaponHammer = true;
        }
        if (rand>=20&&rand<30)  //10%概率掉落武器盾1
        {
            shield1 = GameObject.Instantiate (shield1, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity) as GameObject;
            player.GetComponent<RpgScript> ().dropShield1 = true;
        }
        if (rand >=30&&rand<40)  //10%概率掉落武器盾2
        {
            shield2 = GameObject.Instantiate (shield2, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity) as GameObject;
            player.GetComponent<RpgScript> ().dropShield2 = true;
        }
        if (rand >= 40&&rand<50) //10%概率掉落武器盾3
        {
            shield3 = GameObject.Instantiate (shield3, new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity) as GameObject;
            player.GetComponent<RpgScript> ().dropShield3 = true;
        }
    }
    //伤害飘字函数
    public static void FlyTo (Graphic graphic) {
        RectTransform rt = graphic.rectTransform;
        Color c = graphic.color;
        c.a = 0;
        graphic.color = c;
        Sequence mySequence = DOTween.Sequence ();
        Tweener move1 = rt.DOMoveY (rt.position.y + 50, 0.5f);
        Tweener move2 = rt.DOMoveY (rt.position.y + 100, 0.5f);
        Tweener alpha1 = graphic.DOColor (new Color (c.r, c.g, c.b, 1), 0.5f);
        Tweener alpha2 = graphic.DOColor (new Color (c.r, c.g, c.b, 0), 0.5f);
        mySequence.Append (move1);
        mySequence.Join (alpha1);
        // mySequence.AppendInterval(1);
        mySequence.Append (move2);
        mySequence.Join (alpha2);
    }
}