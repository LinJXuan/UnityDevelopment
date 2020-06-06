using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Plus2 : MonoBehaviour {
    public static float x = 0;
    public void hit_test() {
        x += 1;
        string str = x.ToString();
        GameObject.Find("Canvas/Number2").GetComponent<Text>().text = str;
    }
}
