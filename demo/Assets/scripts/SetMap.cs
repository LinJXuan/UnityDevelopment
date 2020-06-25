using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    private Statistic s;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    private Player player;

    public List<GameObject> MapList=new List<GameObject>();

    void Awake()
    {
        s=Statistic.getInstance();
        normal=NormalEnemy.getInstance();
        expert=ExpertEnemy.getInstance();
        boss=BossEnemy.getInstance();
        player=Player.getInstance();
        //设置本关map
        MapList[s.getMap()-1].SetActive(true);
        //TODO 设置本关怪物属性


        normal.setSpeed(1);
        normal.setRange(3);

        expert.setSpeed(2);
        expert.setRange(3);

        boss.setSpeed(4);
        boss.setRange(3);
    }

    void Update(){


    }

    
}
