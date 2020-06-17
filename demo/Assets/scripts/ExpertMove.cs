using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertMove : MonoBehaviour
{
    private bool look=false;
    private Vector3 position;
    public GameObject player;
    private int speed;
    private ExpertEnemy expert;
    private int attackRange;
    private bool move=true;
    private bool escape=false;
    private float time=5;
    void Start()
    {
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
                escape=true;
            }else{
                move=true;
                escape=false;
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
            if(escape){
                time-=Time.deltaTime;
                if(time<=0){
                    transform.position-=(transform.forward*5);
                    time=5;
                }                
            }

    }
}
