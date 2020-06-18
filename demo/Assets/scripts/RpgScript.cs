
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    //使用状态控制人物动作
    public enum State { dead,stop,left,right,skillOne,skillTwo,skillThree,skillFour}
    public State currentState = State.stop;

    private int enemyLayer;

    private float barUpLength = 3f;
    public Slider healthSlider ; 
    public Slider shieldSlider;
    public static GameObject flaptext;
    public Text flapWord;


    void Start()
    {
        player=Player.getInstance();
        anim =GetComponent<Animator>();
        enemyLayer = LayerMask.GetMask("Enemy");
        flaptext=GameObject.Find("flapWord");
        flaptext.SetActive(false);
        healthSlider.value=GetComponent<PlayerHealth>().playerHp;
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value=GetComponent<PlayerHealth>().playerHp;
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;
        attackDamage=player.getAttack();


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
        flapWord.transform.position=new Vector3(screenPos.x+200f, screenPos.y+30f, screenPos.z);
        
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

    public void setMaxHpUi(int maxHp)
    {
        healthSlider.maxValue = maxHp;
    }
}
