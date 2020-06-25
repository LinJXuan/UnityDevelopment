using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    private Statistic statistic;
    public List<GameObject> map=new List<GameObject>();   
    void Awake()
    {
        statistic=Statistic.getInstance();
        for(int i=0;i<4;i++){
            if(statistic.getSuccess(i)){
                map[i].SetActive(true);
            }
        }
    }


}
