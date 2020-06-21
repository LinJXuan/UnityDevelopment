
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
    private bool isAlive = true;
    public int attackRange = 4;
    public int attackDamage;
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

    private Player player;
    //突刺攻击有关
    private ArrayList enemys = new ArrayList();
    private float spurLength = 5;
    //投掷距离
    private float throwLength = 10;
    //投掷范围
    private float throwRange = 3;
    //圣光范围
    private float lightRange = 3;
    void Start()
    {
        player=Player.getInstance();
        attackDamage=player.getAttack();
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
            holyLightSkill();
        }

        if (currentState == State.skillThree)
        {

            anim.SetTrigger("E Trigger");
            throwSkill();
        }

        if (currentState == State.skillFour)
        {

            anim.SetTrigger("R Trigger");
            spurSkill();
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

    public void setMaxHpUi(int maxHp)
    {
        healthSlider.maxValue = maxHp;
    }

    public void spurSkill()
    {
        print("=====突刺=====");
        Vector3 spurAttack = gameObject.transform.localPosition;
        Vector3 finalPosition = gameObject.transform.localPosition;
        spurAttack.x += transform.forward.x * spurLength / 2;
        finalPosition.x += transform.forward.x * spurLength;
        Collider[] colliders = Physics.OverlapSphere(spurAttack, spurLength/2);
        if (colliders.Length == 0)
        {
            return;
        }
        for(int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController>();
            if (controller != null)
            {
                //攻击伤害为150%
                controller.TakeDamage(attackDamage+attackDamage/2);
            }
        }
        gameObject.transform.localPosition = finalPosition;
    }

    public void throwSkill()
    {
        print("=====投掷=====");
        Vector3 throwAttack = gameObject.transform.localPosition;
        throwAttack.x += transform.forward.x * spurLength / 2;
        Collider[] colliders = Physics.OverlapSphere(throwAttack, throwRange);
        if (colliders.Length == 0)
        {
            return;
        }
        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController>();
            if (controller != null)
            {
                //攻击伤害为2000%
                controller.TakeDamage(attackDamage*2);
            }
        }
    }

    public void holyLightSkill()
    {
        print("=====圣光=====");
        Vector3 holyLightAttack = gameObject.transform.localPosition;
        Collider[] colliders = Physics.OverlapSphere(holyLightAttack, lightRange);
        if (colliders.Length == 0)
        {
            return;
        }
        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController>();
            if (controller != null)
            {
                //攻击伤害为300%
                controller.TakeDamage(attackDamage * 3);
            }  
        }
    }
}
