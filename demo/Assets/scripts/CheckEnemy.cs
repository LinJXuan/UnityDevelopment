using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{

    private bool isMoving = false;
    private int direction;
    private float totalTime = 3f;
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
