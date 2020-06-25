using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CreateEnemy : MonoBehaviour
{
    public GameObject Normal;
    public GameObject Expert;
    public GameObject Boss;
    public GameObject enemyPosition;
    private Vector3 positionR;
    private Quaternion rotationR;
    private int[] enemyCount = new int[3] {0,0,0};
    private int totalCount = 0;
    private int count;
    public bool isCreate=false;

    private SetCreateEnemy set;
    private Statistic s;
    private int Map;
    //文件读写
    private int[,] AmountOfEnemy=new int[30,10];
    private int start;
    private bool move;
    private Csv csv;
    void Start()
    {
        set=GameObject.Find("RPG-Character").GetComponent<SetCreateEnemy>();
        //dtTime = totalTime;
        positionR = enemyPosition.transform.localPosition;
        rotationR = enemyPosition.transform.localRotation;
        s=Statistic.getInstance();
        Map=s.getMap();

        csv=Csv.getInstance();
        start=0;
        count=0;
        csv.readCsv(AmountOfEnemy,Application.dataPath+"/Resources","MapSelect.csv",Map,ref count);

    }


    void Update()
    {
        totalCount=enemyCount[0]+enemyCount[1]+enemyCount[2];
        
        if(isCreate){      
            
            EnemyCreateControl();
            move=true;
            
            print("======= create enemy ======");
        }
        
        if(move){
            int mile=0;
            mile=AmountOfEnemy[start,3];
            enemyCount[0]=AmountOfEnemy[start,4];
            enemyCount[1]=AmountOfEnemy[start,5];
            enemyCount[2]=AmountOfEnemy[start,6];

            enemyPosition.transform.position=new Vector3(mile,enemyPosition.transform.position.y,enemyPosition.transform.position.z);
            set.closeTo15=true;
            positionR = enemyPosition.transform.localPosition;
            rotationR = enemyPosition.transform.localRotation;


            if(isCreate){
                isCreate=false;
            }

            move=false;
            if((start+1)<=count){
            start++;
            }
        }


     }

    private void EnemyCreateControl(){
        for(int i=0;i<enemyCount[0];i++){
            GameObject enemy=Instantiate(Normal, positionR, rotationR);
            enemy.SetActive(true);
            
        }

        for(int i=0;i<enemyCount[1];i++){
            GameObject enemy=Instantiate(Expert, positionR+new Vector3(5,0,0), rotationR);
            enemy.SetActive(true);
            
        }

        for(int i=0;i<enemyCount[2];i++){
            GameObject enemy=Instantiate(Boss, positionR, rotationR);
            print(enemy.transform.localPosition.y);
            enemy.SetActive(true);
            
        }
    }

}
 