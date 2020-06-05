using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{

    private bool isMoving = false;
    private int direction;
    private float totalTime = 3f;
    private float dtTime;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        dtTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (isMoving)
        {
            GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(direction);
            return;
        }
        if (other.name != "airpos"&&PlayerAttribute.currentHp>0)
        {
            print(other.name);
            if (dtTime > totalTime)
            {
                GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(1);
                dtTime = 0;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

    public void IsMoving(bool move,int i)
    {
        isMoving = move;
        direction = i;
    }
}
