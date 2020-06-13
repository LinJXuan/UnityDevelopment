using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToLevel2 : MonoBehaviour
{
    private int count = 0;
    private int down = 6;
    private float intervalTime = 1;
    private bool State = false;
    private Statistic s;
    public GameObject countDown;
    public Text text;
    private Player p;
    // Start is called before the first frame update
    void Start()
    {
        s = Statistic.getInstance();
        p = Player.getInstance();
        text = GameObject.Find("Canvas/countDown").GetComponent<Text>();
        countDown.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // todo 检测敌人数量或者角色血量判断弹出text的内容以及跳转的目标
        //搜索当前敌人数量
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Boss");
        count = gos.Length;
        if (count > 0) { State = true; }
        if (State)
        {
            if (count == 0)
            {
                countDown.SetActive(true);
                if (down > -1)
                {
                    intervalTime -= Time.deltaTime;
                    if (intervalTime <= 0)
                    {
                        intervalTime += 1;
                        down--;
                        text.text = "恭喜你完成本关挑战\n" + down + "秒后跳转到下一关";
                    }
                }
                if (down == 0)
                {
                  
                    SceneManager.LoadScene("Scene3");
                }
            }else if (p.getcurrentHp() == 0)
            {
                countDown.SetActive(true);
                if (down > -1)
                {
                    intervalTime -= Time.deltaTime;
                    if (intervalTime <= 0)
                    {
                        intervalTime += 1;
                        down--;
                        text.text = "你被击败了！\n" + down + "秒后跳转到结算界面";
                    }
                }
                if (down == 0)
                {
                    SceneManager.LoadScene("Statistics");
                }
            }
        }
    }

}
