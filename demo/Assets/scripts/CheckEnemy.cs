using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name != "airpos"&&PlayerAttribute.currentHp!=0)
        {
            //print(other.name + "在检测范围内");
            GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "airpos")
        {
            //print(other.name + "退出检测范围");
            GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(0);
        }
    }
}
