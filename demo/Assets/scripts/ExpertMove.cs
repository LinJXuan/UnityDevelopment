using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertMove : MonoBehaviour
{
    private bool look;
    private Animator anim;
    private Vector3 position;
    public GameObject player;
    private int speed;
    private ExpertEnemy expert;
    private int attackRange;
    private bool move=true;

    private bool isAttacking = false;

    //private bool escape=false;
    //private float time=5;
    void Start()
    {
        look=false;
        anim =GetComponent<Animator>();
        player = GameObject.Find("RPG-Character");
        expert=ExpertEnemy.getInstance();
        transform.LookAt(player.transform);
        position=transform.position;
        speed=expert.getSpeed();
        attackRange=expert.getRange();
        
    }


    void Update()
    {
        float dx = Mathf.Abs(player.transform.localPosition.x - transform.localPosition.x);
            if (dx <= attackRange)
            {
                look=true;
                move=false;
            //    escape=true;
            }else{
                move=true;
            //    escape=false;
            }
            //是否追踪
            if(look && !isAttacking)
            {
                transform.LookAt(player.transform);
            }
            //是否移动
            if(move)
            {
            transform.position += transform.forward * speed * Time.deltaTime;  
            anim.SetBool("Walk",true);
            }else
            {
             anim.SetBool("Walk",false);

            }
            //巡逻
            if(Mathf.Abs(transform.position.x-position.x)>=20){
                

                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;

                position=transform.position;
            }
            //if(escape){
            //    time-=Time.deltaTime;
            //    if(time<=0){
            //        transform.position-=(transform.forward*5);
            //        time=5;
            //    }                
            //}
            //怪物动画接口
            // anim.SetBool("Die", true);     是否播放死亡动画
            // anim.SetBool("Walk", true);    是否行走，动画器在行走时攻击或者受到攻击后默认回到待定状态，Walk为false
            // anim.SetTrigger("Attack");     发起一次攻击
            // anim.SetTrigger("Gethit");     受到一次攻击

    }

    public void setIsAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }
}
