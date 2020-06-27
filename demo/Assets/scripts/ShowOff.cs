using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOff : MonoBehaviour
{
    public Text text;
    public Statistic s;
    private int point;
    public GameObject bgV;
    public GameObject bgD;
    public GameObject bgF;
    public GameObject reStart;
    public GameObject Next;
    void Start()
    {
        s = Statistic.getInstance();
        text = GameObject.Find("End").GetComponent<Text>();
        point = s.getPoint();
        if(s.getComplete()){
            if(s.getMap()<4){
            text.text = "恭喜过关，你离公主更进一步，赶紧进入下一关吧~";
            bgV.SetActive(true);
            Next.SetActive(true);
            }else{
            bgF.SetActive(true);
            }
        }else{
        text.text = "胜败乃兵家常事，公主正在等待被拯救，少侠请再接再厉！";
        bgD.SetActive(true);
        reStart.SetActive(true);
        }
        //s.setSuccess(s.getMap());//解锁地图
    }

}
