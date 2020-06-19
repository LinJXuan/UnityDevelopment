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
        //设置本关level
        s.setLevel(1);
        s.setNextScene("scene3");

        //TODO 设置本关怪物属性

    }

    
}
