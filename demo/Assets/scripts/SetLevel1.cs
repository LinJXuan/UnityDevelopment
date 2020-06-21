using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel1 : MonoBehaviour
{
    private Statistic s;
    private NormalEnemy normal;
    private ExpertEnemy expert;
    private BossEnemy boss;
    void Awake()
    {
        s=Statistic.getInstance();
        normal=NormalEnemy.getInstance();
        expert=ExpertEnemy.getInstance();
        boss=BossEnemy.getInstance();
        //设置本关map
        s.setMap(1);
        s.setNextScene("scene3");

        //TODO 设置本关怪物属性

        normal.setAttack(10);
        normal.setHp(50);
        normal.setSpeed(1);
        normal.setRange(1);

        expert.setAttack(15);
        expert.setHp(83);
        expert.setSpeed(2);
        expert.setRange(3);

        boss.setSpeed(4);
        boss.setRange(3);
    }

    
}
