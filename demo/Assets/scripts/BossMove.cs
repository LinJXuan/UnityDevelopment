using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{
    private bool look=false;
    private Vector3 position;
    public GameObject player;
    private int speed;
    private BossEnemy boss;
    private int attackRange;
    private bool move=true;
    private double Hp;
    private double anger;
    private double power;
    //灼烧攻击距离
    private int burnRange=10;
    private int burnDamage=10;
    //漫水攻击距离
    private int waterPoloRange = 10;
    private int waterPoloDamage = 10;
    //洼陷攻击距离
    private int hollowRange = 10;
    private int hollowDamage = 10;
    //毒液攻击距离
    private int venomRange = 12;
    private int venomDamage = 12;
    //毒火攻击距离
    private int poisonFireRange = 15;
    private int poisonFireDamage = 15;
    //石头炸弹攻击距离
    private int bombRange = 10;
    private int bombDamage = 10;
    public Slider angerValue;
    public Animator Boos1Anim;
    public Animator Boos2Anim;
    public Animator Boos3Anim;
    public Animator Boos4Anim;

    void Start()
    {
        player = GameObject.Find("RPG-Character");
        boss=BossEnemy.getInstance();
        transform.LookAt(player.transform);
        position=transform.position;
        speed=boss.getSpeed();
        attackRange=boss.getRange();
        Hp=boss.getHp();
        anger=boss.getHp()*0.3;
        power=Hp-boss.getcurrentHp();
        angerValue.maxValue=(float)anger;
        angerValue.value=(float)power;
    }


    void Update()
    {
        Vector3 enemyPosition = transform.position;
        enemyPosition.y = player.transform.position.y;
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //怒气条位置
        angerValue.transform.position = new Vector3 (screenPos.x, screenPos.y-10f, screenPos.z);
        angerValue.value=(float)power;
        float dx = Mathf.Abs(player.transform.localPosition.x - transform.localPosition.x);
            if (dx <= attackRange)
            {
                look=true;
                move=false;
            }else{
                move=true;
            }
            //是否追踪
            if(look)
            {
                transform.LookAt(player.transform);
                burnSkill();
            }
            //是否移动
            if(move)
            {
            transform.position += transform.forward * speed * Time.deltaTime; 
            switch (transform.name[4])
                {
                    case '1':
                        Boos1Anim.SetBool("Walk",true);
                        break;
                    case '2':
                        Boos2Anim.SetBool("Walk",true);

                        break;
                    case '3':
                        Boos3Anim.SetBool("Walk",true);
                        
                        break;
                    case '4':
                        Boos4Anim.SetBool("Walk",true);
                       
                        break;

                } 
            }else{
                switch (transform.name[4])
                {
                    case '1':
                        Boos1Anim.SetBool("Walk",false);
                        break;
                    case '2':
                        Boos2Anim.SetBool("Walk",false);

                        break;
                    case '3':
                        Boos3Anim.SetBool("Walk",false);
                        
                        break;
                    case '4':
                        Boos4Anim.SetBool("Walk",false);
                       
                        break;

                } 





            }
            //巡逻
            if(Mathf.Abs(transform.position.x-position.x)>=20){
                Quaternion rotation = transform.localRotation;
                rotation.y = -rotation.y;
                transform.rotation = rotation;
                position=transform.position;
            }
            power=Hp-boss.getcurrentHp();
            //怒气值设定
            if(power>=anger){
                Hp=boss.getcurrentHp();
                //TODO 怒意值满值，发动技能
                //技能逻辑
                switch (transform.name[4])
                {
                    case '1':
                        Boos1Anim.SetTrigger("Attack");
                        burnSkill();
                        break;
                    case '2':
                        Boos2Anim.SetTrigger("Attack");
                        waterPoloSkill();
                        break;
                    case '3':
                        Boos3Anim.SetTrigger("Attack");
                        hollowSkill();
                        break;
                    case '4':
                        Boos4Anim.SetTrigger("Attack");
                        venomSkill();
                        break;
                    case '5':
                        //Boos5Anim.SetTrigger("Attack");
                        poisonFireSkill();
                        break;

                }
            }
        //怪物动画接口  boss1 2 3 4分别为Boss1/2/3/4Anim.Set...
        // Boss1Anim.SetBool("Die", true);     是否播放死亡动画
        // Boss1Anim.SetBool("Walk", true);    是否行走，动画器在行走时攻击或者受到攻击后默认回到待定状态，Walk为false
        // Boss1Anim.SetTrigger("Attack");     发起一次攻击
        // Boss1Anim.SetTrigger("Gethit");     受到一次攻击
    }

    //灼烧
    public void burnSkill()
    {
        print("=====灼烧=====");
        Vector3 burnAttack = gameObject.transform.localPosition;
        burnAttack.x += transform.forward.x * burnRange / 2;
        attack(burnAttack, burnRange, burnDamage);
    }
    //水球
    public void waterPoloSkill()
    {
        print("=====漫水=====");
        Vector3 waterPoloAttack = gameObject.transform.localPosition;
        waterPoloAttack.x += transform.forward.x * waterPoloRange / 2;
        attack(waterPoloAttack, waterPoloRange, waterPoloDamage);
    }
    //洼陷
    public void hollowSkill()
    {
        print("=====洼陷=====");
    }
    //毒液
    public void venomSkill()
    {
        print("=====毒液=====");
        Vector3 venomAttack = gameObject.transform.localPosition;
        venomAttack.x += transform.forward.x * venomRange / 2;
        attack(venomAttack, venomRange, venomDamage);
    }
    //毒火
    public void poisonFireSkill()
    {
        print("=====毒火=====");
        Vector3 poisonAttack = gameObject.transform.localPosition;
        poisonAttack.x += transform.forward.x * poisonFireRange / 2;
        attack(poisonAttack, poisonFireRange, poisonFireDamage);
    }
    //炸弹
    public void bombSkill()
    {
        print("=====炸弹=====");
        Vector3 bombAttack = gameObject.transform.localPosition;
        bombAttack.x += transform.forward.x * bombRange / 2;
        attack(bombAttack, bombRange, bombDamage);
    }

    public void attack(Vector3 attackPosition,int attackRange,int damage)
    {
        Collider[] colliders = Physics.OverlapSphere(attackPosition, attackRange / 2);
        if (colliders.Length == 0)
        {
            return;
        }
        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].gameObject.name);
            PlayerHealth playerHealth = colliders[i].gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
