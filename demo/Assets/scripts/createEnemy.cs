using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CreateEnemy : MonoBehaviour
{
    public GameObject Normal;
    public GameObject Expert;
    public List<GameObject> BossList=new List<GameObject>();
    private GameObject Boss;
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
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    private Player player;
    void Start()
    {
        set=GameObject.Find("RPG-Character").GetComponent<SetCreateEnemy>();

        //dtTime = totalTime;
        positionR = enemyPosition.transform.localPosition;
        rotationR = enemyPosition.transform.localRotation;

        normal=NormalEnemy.getInstance();
        expert=ExpertEnemy.getInstance();
        boss=BossEnemy.getInstance();
        player=Player.getInstance();

        s=Statistic.getInstance();
        Map=s.getMap();
        Boss=BossList[s.getMap()-1];
        csv=Csv.getInstance();
        start=0;
        count=0;
        csv.readCsv(AmountOfEnemy,Application.dataPath+"/prefabs","MapSelect.csv",Map,ref count);

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

            normal.setHp(130+((AmountOfEnemy[start,0]-1)*5+AmountOfEnemy[start,1])*30);
            normal.setAttack(10*2+((AmountOfEnemy[start,0]-1)*5+AmountOfEnemy[start,1])*4);

            expert.setHp(normal.getHp()*5/3);
            expert.setAttack(normal.getAttack()*3/2);

            if(enemyCount[2]>0)
            {
                boss.setHp(player.getHp()*10);
                boss.setAttack(player.getAttack()*5/2);
            }

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
 