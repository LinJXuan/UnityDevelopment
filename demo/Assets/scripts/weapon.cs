using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int Speed=2;
    private GameObject player;
        void Start()
    {
        player=GameObject.Find("RPG-Character");
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up*Speed);
        if((int)player.transform.position.x==(int)transform.position.x){
              Destroy(gameObject);
        }
    }
}
