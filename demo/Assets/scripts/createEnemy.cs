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

    public enum dis{first,second,third,fourth,fifth,last};
    private dis level0=dis.first;
    private SetCreateEnemy set;
    private int Ncount=1;
    private bool newLevel=true;
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
        //dtTime -= Time.deltaTime;
        if(isCreate&&count<enemyCount/*&&dtTime < 0*/){
            count++;
            //dtTime = totalTime;
            //positionL = positionR;
           // positionL.x = -positionR.x;
           // rotationL = rotationR;
           // rotationL.y = -rotationR.y;
            Instantiate(gobjR, positionR, rotationR);
            //Instantiate(gobjR, positionL, rotationL);
            print("======= create enemy ======");
            print("positionL=======" + positionL.y);
        }

        if(newLevel&&count == enemyCount){
            isCreate=false;
            int mile=0;
            level0++;
            switch(level0){
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
            if(level0==dis.fifth){
                newLevel=false;
                level0=dis.first;
            }
            enemyPosition.transform.position=new Vector3(1f*mile,enemyPosition.transform.position.y,enemyPosition.transform.position.z);
            count=0;
            set.closeTo15=true;
            positionR = enemyPosition.transform.localPosition;
            rotationR = enemyPosition.transform.localRotation;
            
        }

        if(!newLevel&&count == enemyCount){
            isCreate=false;
            int mile=0;
            switch(level0){
                case dis.first:
                mile=15;
                break;
                case dis.second:
                mile=30;
                break;
                case dis.third:
                mile=50;
                break;
                case dis.fourth:
                mile=70;
                break;
                case dis.fifth:
                mile=90;
                break;
            }
            mile+=Ncount*100;
            enemyPosition.transform.position=new Vector3(1f*mile,enemyPosition.transform.position.y,enemyPosition.transform.position.z);
            count=0;
            set.closeTo15=true;
            positionR = enemyPosition.transform.localPosition;
            rotationR = enemyPosition.transform.localRotation;
            level0++;
            if(level0==dis.last){
                Ncount++;
                level0=dis.first;
            }
        }
    }
}
