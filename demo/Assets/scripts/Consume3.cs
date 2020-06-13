using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Consume3 : MonoBehaviour {
    // Start is called before the first frame update
    public bool isTiming; //是否开始计时
    public float countDown; //倒计时
    public Button butt; //初始化按钮
    public Sprite image; //初始化图片
    public GameObject consume; //初始化
    void Start(){
        countDown = 0;
    }
    void Update () {
        Detection (); //调用检测函数
    }
    public void click () {
        if (countDown == 0) //当倒计时时间等于0的时候
        {
            countDown = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(3)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void Detection () {
        if (isTiming) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown) > 10) //如果 两次点击时间间隔大于2秒
            {
                countDown = 0; //倒计时时间归零
                isTiming = false; //关闭倒计时
            }
        }
    }
}