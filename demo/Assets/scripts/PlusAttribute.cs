using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlusAttribute : MonoBehaviour {
    private Player p;
    public int playerHp;
    public int playerDefense;
    public int playerAttack;
    public int playerlevelPoint;
    void Start () {
        p = Player.getInstance ();
        playerHp = p.getHp ();
        playerDefense = p.getDefense ();
        playerAttack = p.getAttack ();
        playerlevelPoint = p.getlevelPoint ();
        //p.setlevelPoint(10);
        GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = playerHp.ToString ();
        GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = playerDefense.ToString ();
        GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = playerAttack.ToString ();
        GameObject.Find ("Canvas/Number4").GetComponent<Text> ().text = playerlevelPoint.ToString ();
    }
    void Update() {
        playerHp = p.getHp ();
        playerDefense = p.getDefense ();
        playerAttack = p.getAttack ();
        playerlevelPoint = p.getlevelPoint ();
        GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = playerHp.ToString ();
        GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = playerDefense.ToString ();
        GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = playerAttack.ToString ();
        GameObject.Find ("Canvas/Number4").GetComponent<Text> ().text = playerlevelPoint.ToString ();
    }
    public void plusHp () {
        if (playerlevelPoint > 0) {
            reducelevelPoint ();
            playerHp += 20;
            p.setHp (playerHp);
            string str1 = playerHp.ToString ();
            GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = str1;
        }
    }
    public void plusDefense () {
        if (playerlevelPoint > 0) {
            reducelevelPoint ();
            playerDefense += 3;
            p.setDefense (playerDefense);
            string str2 = playerDefense.ToString ();
            GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = str2;
        }
    }
    public void plusAttack () {
        if (playerlevelPoint > 0) {
            reducelevelPoint ();
            playerAttack += 3;
            p.setAttack (playerAttack);
            string str3 = playerAttack.ToString ();
            GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = str3;
        }
    }
    public void reducelevelPoint () {
        playerlevelPoint -= 1;
        p.setlevelPoint (playerlevelPoint);
        string str4 = playerlevelPoint.ToString ();
        GameObject.Find ("Canvas/Number4").GetComponent<Text> ().text = str4;
    }
}