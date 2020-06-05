using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgScript : MonoBehaviour
{
    private Animator anim;
    public float speed=1;
    private bool right=true;
    private bool isPlaying=false;
    private bool isMoving = false;
    private bool isAlive = true;
    public GameObject enemy;

    public enum State { dead,stop,left,right,skillOne,skillTwo,skillThree,skillFour}
    public State currentState = State.stop;
    //无限地图
    public RoadLoop roadloop;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Airpos")
        {
            roadloop.changeroad(other.transform);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy=GameObject.Find("RPG-enemy R");
        enemy.SetActive(false);
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((int)Time.time==3)
        {
            enemy.SetActive(true);
        }

        if(currentState == State.dead)
        {
            anim.SetBool("dead", true);
        }

        if (!isAlive)
        {
            currentState = State.dead;
            return;
        }

        if (currentState == State.left)
        {
            anim.SetBool("walk",true);
          transform.Translate( new Vector3(0,0,-1) * speed * Time.deltaTime); 
        }
        
        if(currentState ==State.right)
        {
            anim.SetBool("walk",true);
            transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime);
        }

        if(currentState == State.stop)
        {
             
            anim.SetBool("walk",false);
        }
       
        if(currentState == State.skillOne)
        {

            anim.SetTrigger("Q Trigger");
        }

        if(currentState ==State.skillTwo)
        {

            anim.SetTrigger("W Trigger");
        }

        if (currentState == State.skillThree)
        {

            anim.SetTrigger("E Trigger");
        }

        if (currentState == State.skillFour)
        {

            anim.SetTrigger("R Trigger");
        }

        if (currentState != State.left && currentState != State.right)
        {
            currentState = State.stop;
        }
        
    }
    public void FootR()
     {

     } 
    public void FootL()
    {

    } 
    public void Hit()
    {

    }

    public void setState(int i)
    {
        if(i == -1 || i == -2)
        {
            if (isPlaying)
            {
                //直接返回
                return;
            }
            else
            {
                //不做处理，让switch去设置移动
            }
        }

        switch (i)
        {
            case -3:
                currentState = State.dead;
                break;
            case -1:
                currentState = State.left;
                break;
            case -2:
                currentState = State.right;
                break;
            case 0:
                currentState = State.stop;
                break;
            case 1:
                currentState = State.skillOne;
                break;
            case 2:
                currentState = State.skillTwo;
                break;
            case 3:
                currentState = State.skillThree;
                break;
            case 4:
                currentState = State.skillFour;
                break;

        }
    }

    public void playerIsAlive(bool alive)
    {
        isAlive = alive;
    }

    void AnimatorEventFinishCallBack()
    {
        isPlaying = false;
    }

    void AnimatorEventBeginCallBack()
    {
        isPlaying = true;
    }

    void DeadFinshCallBack()
    {
        isPlaying = false;
    }

}
