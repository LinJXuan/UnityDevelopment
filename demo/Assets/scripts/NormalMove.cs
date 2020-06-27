using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMove : MonoBehaviour
{
    private bool look=false;
    private Vector3 position;
    public GameObject player;
    private int speed;
    private NormalEnemy normal;
    private Animator anim;
    private int attackRange;
    private bool move=true;
    void Start()
    {
        anim =GetComponent<Animator>();
        player = GameObject.Find("RPG-Character");
        normal=NormalEnemy.getInstance();
        transform.LookAt(player.transform);
        position=transform.position;
        speed=normal.getSpeed();
        attackRange=normal.getRange();
        
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
            anim.SetBool("Walk",true);
            }
            else{
            anim.SetBool("Walk",false);

            }
            //巡逻
            if(Mathf.Abs(transform.position.x-position.x)>=20){
                

                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;

                position=transform.position;
            }
            

    }
}
