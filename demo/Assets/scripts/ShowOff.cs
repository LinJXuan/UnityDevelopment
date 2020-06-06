using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOff : MonoBehaviour
{
    public Text text;
    public Statistic s;
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        s = Statistic.getInstance();
        text = GameObject.Find("End").GetComponent<Text>();
        point = s.getPoint();
        text.text = "游戏结束\n你获得的分数是：" + point + "\n请点击返回按钮返回主菜单";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
