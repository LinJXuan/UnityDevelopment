﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RpgScript : MonoBehaviour
{
    private Animator anim;
    public float speed=1;
    private bool isRight = true;
    private bool isLeft = false;
    private bool isPlaying=false;
    private bool isMoving = false;
    private bool isAlive = true;
    public int attackRange = 4;
    public int attackDamage = 10;
    public GameObject enemy;
    //倒计时组件
    private int countDown = 3;
    private float intervalTime = 1;
    //使用状态控制人物动作
    public enum State { dead,stop,left,right,skillOne,skillTwo,skillThree,skillFour}
    public State currentState = State.stop;

    private int enemyLayer;
    /*
     * 无限地图
     */
    public Transform Player;
    private Vector3 initPosition;
    public List<Transform> roadlist = new List<Transform>();
    public List<Transform> walllist = new List<Transform>();
    private float barUpLength = 3f;
    public Slider healthSlider ; 
    public Slider shieldSlider;
    public static GameObject flaptext;
    public Text flapWord;
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
        enemy.SetActive(false);
        initPosition = Player.position;
        anim =GetComponent<Animator>();
        enemyLayer = LayerMask.GetMask("Enemy");
        flaptext=GameObject.Find("flapWord");
        flaptext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        infMap();
        if (countDown > -1)
        {
            intervalTime -= Time.deltaTime;
            if (intervalTime <= 0)
            {
                intervalTime += 1;
                countDown--;

            }
        }

        if (countDown == 0)
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
            if (!isLeft)
            {
                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;
                isLeft = true;
                isRight = false;
                print("转向====> " + transform.rotation);
            }
            anim.SetBool("walk",true);
            transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime); 
        }
        
        if(currentState ==State.right)
        {
            if (!isRight)
            {
                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;
                isRight = true;
                isLeft = false;
                print("转向====> " + transform.rotation);
            }
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
            flaptext.SetActive(true);     //显示伤害
            FlyTo(flapWord);
        }

        if(currentState ==State.skillTwo)
        {

            anim.SetTrigger("W Trigger");
            flaptext.SetActive(true);     //显示伤害
            FlyTo(flapWord);
        }

        if (currentState == State.skillThree)
        {

            anim.SetTrigger("E Trigger");
            flaptext.SetActive(true);     //显示伤害
            FlyTo(flapWord);
        }

        if (currentState == State.skillFour)
        {

            anim.SetTrigger("R Trigger");
            flaptext.SetActive(true);     //显示伤害
            FlyTo(flapWord);
        }

        if (currentState != State.left && currentState != State.right)
        {
            currentState = State.stop;
        }
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + barUpLength , transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        //血条位置
        healthSlider.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
        //护盾位置
        shieldSlider.transform.position = new Vector3(screenPos.x, screenPos.y-9.7693f, screenPos.z);
        //伤害飘字的位置
        flapWord.transform.position=new Vector3(screenPos.x+300f, screenPos.y+30f, screenPos.z);
        //受到伤害（目前为按键盘D受到10点伤害）
        if(Input.GetKeyDown(KeyCode.D)){
            if(shieldSlider.value>=10)
            {
            shieldSlider.value -=10;
            }else{
             healthSlider.value -=10;
            }
            
        }
        
    }
    public void FootR()
     {

     } 
    public void FootL()
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

    void Hit()
    {
        Ray attackRay = new Ray();
        attackRay.origin = transform.position;
        attackRay.direction = transform.forward;
        if (Physics.Raycast(attackRay, out RaycastHit attackHit, attackRange, enemyLayer))
        {
            EnemyHealth enemyHealth = attackHit.collider.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(attackDamage);
        }
    }
    void DeadFinshCallBack()
    {
        isPlaying = false;
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
