using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlusAttribute : MonoBehaviour {
    private Player p;
    private static int playerHp;
    private static int playerDefense;
    private static int playerAttack;
    private static int playerLevelPoint;

    void Start () {
        p = Player.getInstance ();
        playerHp = p.getHp ();
        playerDefense = p.getDefense ();
        playerAttack = p.getAttack ();
        playerLevelPoint = p.getlevelPoint ();
        playerLevelPoint = 5;
        GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = playerHp.ToString ();
        GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = playerDefense.ToString ();
        GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = playerAttack.ToString ();
        GameObject.Find ("Canvas/Number4").GetComponent<Text> ().text = playerLevelPoint.ToString ();
    }
    public void reduceLevelPoint () {
        playerLevelPoint -= 1;
        p.setlevelPoint (playerLevelPoint);
        string str4 = playerLevelPoint.ToString ();
        GameObject.Find ("Canvas/Number4").GetComponent<Text> ().text = str4;
    }
    public void plusHp () {
        if (playerLevelPoint > 0) {
            reduceLevelPoint ();
            playerHp += 20;
            p.setHp (playerHp);
            string str1 = playerHp.ToString ();
            GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = str1;
        }
    }
    public void plusDefense () {
        if (playerLevelPoint > 0) {
            reduceLevelPoint ();
            playerDefense += 3;
            p.setDefense (playerDefense);
            string str2 = playerDefense.ToString ();
            GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = str2;
        }
    }
    public void plusAttack () {
        if (playerLevelPoint > 0) {
            reduceLevelPoint ();
            playerAttack += 3;
            p.setAttack (playerAttack);
            string str3 = playerAttack.ToString ();
            GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = str3;
        }
    }
}