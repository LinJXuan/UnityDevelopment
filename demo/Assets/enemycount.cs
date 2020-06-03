using System.Collections;
using System.Collections.Generic;
//using Unity.UIWidgets.widgets;
using UnityEngine;
using UnityEngine.UI;
public class enemycount : MonoBehaviour
{
    private Text text;
    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas/count").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        count = gos.Length;
        text.text = "当前共有" + count.ToString() + "名敌人";
    }
}
