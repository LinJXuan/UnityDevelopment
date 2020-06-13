using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float totalTime = 3;
    private float dtTime;
    //public GameObject gobjL;
    public GameObject gobjR;
    public GameObject enemyPosition;
    private Vector3 positionL;
    private Vector3 positionR;
    private Quaternion rotationL;
    private Quaternion rotationR;
    public int enemyCount = 10;
    private int count = 0;
    public bool isCreate=false;

    public enum dis{first,second,third,fourth};
    private dis level0=dis.first;
    private SetCreateEnemy set;
    // Start is called before the first frame update
    void Start()
    {
        set=GameObject.Find("RPG-Character").GetComponent<SetCreateEnemy>();
        //dtTime = totalTime;
        positionR = enemyPosition.transform.localPosition;
        rotationR = enemyPosition.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        // dtTime -= Time.deltaTime;
        // if (dtTime < 0&&count< enemyCount)
        // {
        //     count++;
        //     dtTime = totalTime;

        //     positionL = positionR;
        //     positionL.x = -positionR.x;
        //     rotationL = rotationR;
        //     rotationL.y = -rotationR.y;
        //     Instantiate(gobjR, positionR, rotationR);
        //     //Instantiate(gobjR, positionL, rotationL);
        //     print("======= create enemy ======");
        //     print("positionL=======" + positionL.y);
        // }
        dtTime -= Time.deltaTime;
        if(isCreate&&count<enemyCount&&dtTime < 0){
            count++;
            dtTime = totalTime;
            //positionL = positionR;
           // positionL.x = -positionR.x;
           // rotationL = rotationR;
           // rotationL.y = -rotationR.y;
            Instantiate(gobjR, positionR, rotationR);
            //Instantiate(gobjR, positionL, rotationL);
            print("======= create enemy ======");
            print("positionL=======" + positionL.y);
        }

        if(count == enemyCount){
            isCreate=false;
            int mile=0;
            switch(level0){
                case dis.first:
                mile=20;
                break;
                case dis.second:
                mile=45;
                break;
                case dis.third:
                mile=70;
                break;
                case dis.fourth:
                mile=90;
                break;
            }
            enemyPosition.transform.position+=new Vector3(1f*mile,0,0);
            count=0;
            set.closeTo15=true;
        }
    }
}
