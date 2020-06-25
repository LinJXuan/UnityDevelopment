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
        if(statistic.getSuccess(1)){
            GameObject.Find ("Button2").SetActive(false);
        }
        if(statistic.getSuccess(2)){
            GameObject.Find ("Button3").SetActive(false);
        }
        if(statistic.getSuccess(3)){
            GameObject.Find ("Button4").SetActive(false);
        }
        for(int i=0;i<4;i++){
            if(statistic.getSuccess(i)){
                map[i].SetActive(true);
            }
            else{
                map[i].SetActive(false);
            }
        }
    }

}
