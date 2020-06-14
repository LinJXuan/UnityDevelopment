using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 4;
    public float attackRange = 2;
    public float timeAttack = 5f;
    public int attachDamage = 30;
    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    public bool isCreate=false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("RPG-Character").GetComponent<PlayerHealth>();
        player = GameObject.Find("RPG-Character");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
            //transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime); 
            
            if (time >= timeAttack)
            {
               
                float dx = Mathf.Abs(player.transform.localPosition.x - transform.localPosition.x);
                if (dx < attackRange)
                {
                    Attack();
                }
            }
        }
    }

    public void Attack()
    {
        time = 0;
        playerHealth.TakeDamage(attachDamage);
    }
}
