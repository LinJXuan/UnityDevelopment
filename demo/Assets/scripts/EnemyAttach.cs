using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttach : MonoBehaviour
{
    public int attachDamage = 10;
    public float timeAttack = 0.5f;
    private bool playerInRange = false;
    private GameObject player;
    private PlayerHealth playerHealth;
    private float time;    //距离上一次怪物输出的时间
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("RPG-Character");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (playerInRange && time >= timeAttack && playerHealth.playerHp > 0)
        {
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    private void Attack()
    {
        time = 0;
        playerHealth.TakeDamage(attachDamage);
    }
}
