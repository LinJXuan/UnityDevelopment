using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    // Start is called before the first frame update
    private Button title;
    private Statistic s;
    private GameObject Object1;
    //private Button mainbody;//正文
    public int count;
    public static int dialogCount; //决定对话的参数
    void Awake () {
        dialogCount = 0;
        s = Statistic.getInstance ();
    }
    void Start () {
        Object1 = GameObject.Find ("Canvas1/dialog");
        title = Object1.GetComponent<Button> ();
        //mainbody = GameObject.Find ("Canvas1/mainbody").GetComponent<Button>();
        count = 1;
        if (s.getMap()==1){
            dialogCount = 0;
        }
        if (s.getMap()==2){
            dialogCount = 2;
        }
        if (s.getMap()==3){
            dialogCount = 3;
        }
        if (s.getMap()==4){
            dialogCount = 4;
        }
        GoOn ();
    }

    // Update is called once per frame
    void Update () {

    }
    public void GoOn () {
        if (dialogCount == 0) {
            starterVillage ();
        }
        if (dialogCount == 1) {
            diaBox1 ();
        }
        if (dialogCount == 2) {
            diaBox2 ();
        }
        if (dialogCount == 3) {
            diaBox3 ();
        }
        if (dialogCount == 4) {
            diaBox4 ();
        }
        if (dialogCount == 5) {
            defeatDragon ();
        }
    }
    private void diaBox1 () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "关卡1——荒野";
                mainText.text = "这个地也太荒凉了吧。。。";
                count++;
                break;
            case 2:
                titleText.text = "关卡1——荒野";
                mainText.text = "为了我亲爱的公主，出发吧！";
                count++;
                break;
            case 3:
                Object1.SetActive (false);
                count = 1;
                break;
        }
    }
    private void diaBox2 () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "关卡2——森林";
                mainText.text = "荒野背后居然是一片森林";
                count++;
                break;
            case 2:
                titleText.text = "关卡2——森林";
                mainText.text = "我的公主会在这吗？";
                count++;
                break;
            case 3:
                Object1.SetActive (false);
                count = 1;
                break;
        }
    }
    private void diaBox3 () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "关卡3——山洞";
                mainText.text = "阴森森的山洞。。。";
                count++;
                break;
            case 2:
                titleText.text = "关卡3——山洞";
                mainText.text = "希望不要遇到什么不干净的东西";
                count++;
                break;
            case 3:
                Object1.SetActive (false);
                count = 1;
                break;
        }
    }
    private void diaBox4 () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "关卡4——城堡";
                mainText.text = "恶龙一定在城堡里面，终于要结束这一切了";
                count++;
                break;
            case 2:
                titleText.text = "关卡4——城堡";
                mainText.text = "为了我亲爱的公主，冲冲冲！";
                count++;
                break;
            case 3:
                Object1.SetActive (false);
                count = 1;
                break;
        }
    }
    private void starterVillage () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "新手村";
                mainText.text = "欢迎来到我们的游戏，接下来介绍一下游戏的基本玩法";
                count++;
                break;
            case 2:
                titleText.text = "新手村";
                mainText.text = "首先点击方向键，可以左右移动";
                count++;
                break;
            case 3:
                titleText.text = "新手村";
                mainText.text = "点击按键1可以发动普通攻击";
                count++;
                break;
            case 4:
                titleText.text = "新手村";
                mainText.text = "点击技能，可以释放技能";
                count++;
                break;
            case 5:
                titleText.text = "新手村";
                mainText.text = "注意，不同技能cd时间也不同";
                count++;
                break;
            case 6:
                titleText.text = "新手村";
                mainText.text = "人物升级后，可以分配升级点数";
                count++;
                break;
            case 7:
                titleText.text = "新手村";
                mainText.text = "获取武器后可以进行更换";
                count++;
                break;
            case 8:
                count = 1;
                dialogCount = 1;
                break;
        }
    }
    private void defeatDragon () {
        Text titleText = title.transform.Find ("title").GetComponent<Text> ();
        Text mainText = title.transform.Find ("mainbody").GetComponent<Text> ();
        switch (count) {
            case 1:
                titleText.text = "打败恶龙";
                mainText.text = "亲爱的勇士，恭喜你，结束了这一切";
                count++;
                break;
            case 2:
                titleText.text = "新手村";
                mainText.text = "终于打败了恶龙，救回了美丽的公主";
                count++;
                break;
            case 3:
                titleText.text = "新手村";
                mainText.text = "我们的游戏到这里就结束了，感谢你的游玩";
                count++;
                break;
            case 4:
                Object1.SetActive (false);
                count = 1;
                break;
        }
    }
}