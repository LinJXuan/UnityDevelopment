using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCreateEnemy : MonoBehaviour
{
    //private Vector3 position;
    public Transform enemy;
    private CreateEnemy create;
    public bool closeTo15=true;
    // Start is called before the first frame update
    void Start()
    {
        //position=transform.position;
        create = GameObject.Find("EnemyManager").GetComponent<CreateEnemy>();

    }

    // Update is called once per frame
    void Update()
    {

        if(enemy.position.x-transform.position.x<=15f&&closeTo15){
            create.isCreate=true;
            closeTo15=false;
        }
    }
}
