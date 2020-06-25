using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCreateEnemy : MonoBehaviour
{

    public Transform enemy;
    private CreateEnemy create;
    public bool closeTo15=true;

    void Start()
    {
        //position=transform.position;
        create = GameObject.Find("EnemyManager").GetComponent<CreateEnemy>();

    }


    void Update()
    {

        if(enemy.position.x-transform.position.x<=15f&&closeTo15){
            create.isCreate=true;
            closeTo15=false;
        }
    }
}
