using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    /*
     * 无限地图
     */
    public Transform Player;
    private Vector3 initPosition;
    public List<Transform> roadlist = new List<Transform>();
    public List<Transform> walllist = new List<Transform>();
    public void infMap()
    {
        int lastIndex = roadlist.Count - 1;
        if (Player.position.x - initPosition.x >= 50f)
        {
            roadlist[0].position = roadlist[lastIndex].position + new Vector3(50f, 0, 0);
            walllist[0].position = walllist[lastIndex].position + new Vector3(50f, 0, 0);

            initPosition = Player.position;
            Transform t = roadlist[0];
            roadlist.RemoveAt(0);
            roadlist.Insert(lastIndex, t);
            t = walllist[0];
            walllist.RemoveAt(0);
            walllist.Insert(lastIndex, t);
        }
        else if (Player.position.x-initPosition.x<=-50)
        {
            roadlist[lastIndex].position = roadlist[0].position - new Vector3(50f, 0, 0);
            walllist[lastIndex].position = walllist[0].position - new Vector3(50f, 0, 0);

            initPosition = Player.position;
            Transform t = roadlist[lastIndex];
            roadlist.RemoveAt(lastIndex);
            roadlist.Insert(0, t);
            t = walllist[0];
            walllist.RemoveAt(lastIndex);
            walllist.Insert(0, t);
        }
    }

    void Start()
    {
        enemy=GameObject.Find("RPG-enemy R");
        enemy.SetActive(false);
        initPosition = Player.position;
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        infMap();
        if ((int)Time.time==3)
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
