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
    void Start () {
        p = Player.getInstance ();
        playerHp = p.getHp ();
        playerDefense = p.getDefense ();
        playerAttack = p.getAttack ();
        GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = playerHp.ToString ();
        GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = playerDefense.ToString ();
        GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = playerAttack.ToString ();
    }
    public void plusHp () {
        playerHp += 1;
        p.setHp(playerHp);
        string str1 = playerHp.ToString ();
        GameObject.Find ("Canvas/Number1").GetComponent<Text> ().text = str1;
    }
    public void plusDefense () {
        playerDefense += 1;
        p.setDefense(playerDefense);
        string str2 = playerDefense.ToString ();
        GameObject.Find ("Canvas/Number2").GetComponent<Text> ().text = str2;
    }
    public void plusAttack () {
        playerAttack += 1;
        p.setAttack(playerAttack);
        string str3 = playerAttack.ToString ();
        GameObject.Find ("Canvas/Number3").GetComponent<Text> ().text = str3;
    }
}