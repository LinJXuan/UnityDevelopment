using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 4;
    public float attackRange = 2;
    public float timeAttack = 5f;
    public int attachDamage = 2;
    private Rigidbody rbody;
    private float time;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("RPG-Character").GetComponent<PlayerHealth>();
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
