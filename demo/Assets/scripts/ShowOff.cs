using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOff : MonoBehaviour
{
    public Text text;
    public Statistic s;
    private int point;

    void Start()
    {
        s = Statistic.getInstance();
        text = GameObject.Find("End").GetComponent<Text>();
        point = s.getPoint();
        text.text = "恭喜通过地图"+s.getMap()+"\n你获得的分数是：" + point + "\n请点击返回按钮返回主菜单";
        s.setSuccess(s.getMap());//解锁地图
    }

}
