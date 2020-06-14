using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float totalTime = 1;
    //private float dtTime;
    //public GameObject gobjL;
    public GameObject Normal;
    public GameObject Expert;
    public GameObject Boss;
    public GameObject enemyPosition;
    private Vector3 positionL;
    private Vector3 positionR;
    private Quaternion rotationL;
    private Quaternion rotationR;
    private int[] enemyCount = new int[3] {1,0,0};
    private int totalCount = 0;
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
        totalCount=enemyCount[0]+enemyCount[1]+enemyCount[2];

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
        if(isCreate&&count<totalCount/*&&dtTime < 0*/){
            
            EnemyCreateControl(ref count);
            
            print("======= create enemy ======");
            print("positionL=======" + positionL.y);
        }

        if(newLevel&&count == totalCount){
            isCreate=false;
            int mile=0;
            level0++;
            switch(level0){
                case dis.second:
                mile=45;              
                break;

                case dis.third:
                enemyCount[0]=0;
                enemyCount[1]=1;
                mile=70;
                break;

                case dis.fourth:
                mile=90;
                break;
            }
            if(level0==dis.fifth){
                newLevel=false;
                level0=dis.first;
                enemyCount[1]=0;
            }
            enemyPosition.transform.position=new Vector3(1f*mile,enemyPosition.transform.position.y,enemyPosition.transform.position.z);
            count=0;
            set.closeTo15=true;
            positionR = enemyPosition.transform.localPosition;
            rotationR = enemyPosition.transform.localRotation;
            
        }

        if(!newLevel&&count == totalCount){
            isCreate=false;
            int mile=0;

            switch(level0){
                case dis.first:
                mile=15;
                switch(Ncount){
                    case 1:
                    enemyCount[0]=2;
                    enemyCount[1]=0;
                    break;
                    case 2:
                    enemyCount[0]=2;
                    enemyCount[1]=1;
                    break;
                    case 3:
                    enemyCount[0]=2;
                    enemyCount[1]=0;
                    break;
                    case 4:
                    enemyCount[0]=2;
                    enemyCount[1]=2;
                    break;
                }
                break;

                case dis.second:
                mile=30;
                switch(Ncount){
                    case 1:
                    enemyCount[0]=2;
                    enemyCount[1]=0;
                    break;
                    case 2:
                    enemyCount[0]=2;
                    enemyCount[1]=1;
                    break;
                    case 3:
                    enemyCount[0]=3;
                    enemyCount[1]=2;
                    break;
                    case 4:
                    enemyCount[0]=3;
                    enemyCount[1]=3;
                    break;
                }
                break;

                case dis.third:
                mile=50;
                switch(Ncount){
                    case 1:
                    enemyCount[0]=1;
                    enemyCount[1]=1;
                    break;
                    case 2:
                    enemyCount[0]=2;
                    enemyCount[1]=1;
                    break;
                    case 3:
                    enemyCount[0]=4;
                    enemyCount[1]=3;
                    break;
                    case 4:
                    enemyCount[0]=5;
                    enemyCount[1]=5;
                    break;
                }
                break;

                case dis.fourth:
                mile=70;
                switch(Ncount){
                    case 1:
                    enemyCount[0]=2;
                    enemyCount[1]=1;
                    break;
                    case 2:
                    enemyCount[0]=2;
                    enemyCount[1]=1;
                    break;
                    case 3:
                    enemyCount[0]=5;
                    enemyCount[1]=4;
                    break;
                    case 4:
                    enemyCount[0]=5;
                    enemyCount[1]=5;
                    break;
                }
                break;

                case dis.fifth:
                mile=90;
                switch(Ncount){
                    case 1:
                    enemyCount[0]=1;
                    enemyCount[1]=2;
                    break;
                    case 2:
                    enemyCount[0]=2;
                    enemyCount[1]=2;
                    break;
                    case 3:
                    enemyCount[0]=6;
                    enemyCount[1]=5;
                    break;
                    case 4:
                    enemyCount[0]=0;
                    enemyCount[1]=0;
                    enemyCount[2]=1;
                    break;
                }
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

    private void EnemyCreateControl(ref int count){
        for(int i=0;i<enemyCount[0];i++){
            GameObject enemy=Instantiate(Normal, positionR, rotationR);
            enemy.SetActive(true);
            count++;
        }


        for(int i=0;i<enemyCount[1];i++){
            GameObject enemy=Instantiate(Expert, positionR+new Vector3(5,0,0), rotationR);
            enemy.SetActive(true);
            count++;
        }

        for(int i=0;i<enemyCount[2];i++){
            GameObject enemy=Instantiate(Boss, positionR, rotationR);
            enemy.SetActive(true);
            count++;
        }
    }
}
