using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Consume : MonoBehaviour {
    // Start is called before the first frame update
    public bool isTiming1; //是否开始计时1
    public bool isTiming2; //是否开始计时2
    public bool isTiming3; //是否开始计时3
    public bool isTiming4; //是否开始计时4
    public bool isTiming5; //是否开始计时5
    public bool isTiming6; //是否开始计时6
    public float countDown1; //倒计时1
    public float countDown2; //倒计时2
    public float countDown3; //倒计时3
    public float countDown4; //倒计时4
    public float countDown5; //倒计时5
    public float countDown6; //倒计时6
    public Button butt; //初始化按钮
    public Sprite image; //初始化图片
    public GameObject consume; //初始化
    void Start(){
        countDown1 = 0;
        countDown2 = 0;
        countDown3 = 0;
        countDown4 = 0;
        countDown5 = 0;
        countDown6 = 0;
    }
    void Update () {
        Detection (); //调用检测函数
    }
    public void click1 () {
        if (countDown1 == 0) //当倒计时时间等于0的时候
        {
            countDown1 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming1 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(1)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void click2 () {
        if (countDown2 == 0) //当倒计时时间等于0的时候
        {
            countDown2 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming2 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(2)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void click3 () {
        if (countDown3 == 0) //当倒计时时间等于0的时候
        {
            countDown3 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming3 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(3)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void click4 () {
        if (countDown4 == 0) //当倒计时时间等于0的时候
        {
            countDown4 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming4 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(4)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void click5 () {
        if (countDown5 == 0) //当倒计时时间等于0的时候
        {
            countDown5 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming5 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(5)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void click6 () {
        if (countDown6 == 0) //当倒计时时间等于0的时候
        {
            countDown6 = Time.time; //把游戏开始时间，赋值给CountDown
            isTiming6 = true; //开始计时
        } else {
            consume = GameObject.Find ("Canvas/Consumables/consume(6)"); //绑定GameObject
            butt = consume.GetComponent<Button> (); //绑定按钮
            image = Resources.Load<Sprite> ("RectButtonPressed"); //加载图片
            butt.image.sprite = image; //替换图片
        }
    }
    public void Detection () {
        if (isTiming1) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown1) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown1 = 0; //倒计时时间归零
                isTiming1 = false; //关闭倒计时
            }
        }
        if (isTiming2) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown2) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown2 = 0; //倒计时时间归零
                isTiming2 = false; //关闭倒计时
            }
        }
        if (isTiming3) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown3) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown3 = 0; //倒计时时间归零
                isTiming3 = false; //关闭倒计时
            }
        }
        if (isTiming4) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown4) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown4 = 0; //倒计时时间归零
                isTiming4 = false; //关闭倒计时
            }
        }
        if (isTiming5) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown5) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown5 = 0; //倒计时时间归零
                isTiming5 = false; //关闭倒计时
            }
        }
        if (isTiming6) //如果 IsTiming 为 true 
        {
            if ((Time.time - countDown6) > 2) //如果 两次点击时间间隔大于2秒
            {
                countDown6 = 0; //倒计时时间归零
                isTiming6 = false; //关闭倒计时
            }
        }
    }
}