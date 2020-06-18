
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgScript : MonoBehaviour
{
    private Animator anim;
    public float speed=5;
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

    private float barUpLength = 3f;
    public Slider healthSlider ; 
    public Slider shieldSlider;



    void Start()
    {
        enemy.SetActive(false);
        
        anim =GetComponent<Animator>();
        enemyLayer = LayerMask.GetMask("Enemy");
        healthSlider.value=GetComponent<PlayerHealth>().playerHp;
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value=GetComponent<PlayerHealth>().playerHp;
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;
 
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
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + barUpLength , transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        //血条位置
        healthSlider.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
        //护盾位置
        shieldSlider.transform.position = new Vector3(screenPos.x, screenPos.y-9.7693f, screenPos.z);
      
        
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
            EnemyController EnemyController = attackHit.collider.gameObject.GetComponent<EnemyController>();
            EnemyController.TakeDamage(attackDamage);
        }
    }
    void DeadFinshCallBack()
    {
        isPlaying = false;
    }
     //伤害飘字函数
public void setMaxHpUi(int maxHp)
{
    healthSlider.maxValue=maxHp;
}
}
