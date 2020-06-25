using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{

    private bool isMoving = false;
    private int direction;
    private float totalTime = 5f;
    private float dtTime;
    private Player p;
    public int attackRange = 4;
    private int enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        p = Player.getInstance();
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        dtTime += Time.deltaTime;
        IsAttack();
    }

    public void IsMoving(bool move,int i)
    {
        isMoving = move;
        direction = i;
    }

    //当RpgScript人物有动作时，就重置时间
    //实现无动作totalTime后会进行自动攻击
    public void resetdTime()
    {
        dtTime = 0;
    }
    public void IsAttack()
    {
        Ray attackRay = new Ray();
        attackRay.origin = transform.position;
        attackRay.direction = transform.forward;
        if(Physics.Raycast(attackRay,out RaycastHit attackHit, attackRange, enemyLayer))
        {
            if (isMoving)
            {
                GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(direction);
                return;
            }
            if (p.getcurrentHp() > 0 && dtTime > totalTime)
            {
                GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(1);
                dtTime = 0;
            }
        }
    }
}
