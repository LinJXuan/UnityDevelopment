using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }


    void Update()
    {
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
            }
            //是否移动
            if(move)
            {
            transform.position += transform.forward * speed * Time.deltaTime;  
            }
            //巡逻
            if(Mathf.Abs(transform.position.x-position.x)>=20){
                

                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;

                position=transform.position;
            }
            power=Hp-boss.getcurrentHp();
            //怒气值设定
            if(power>=anger){
                Hp=boss.getcurrentHp();
                //TODO 怒意值满值，发动技能
                //技能逻辑
            }

    }
}
