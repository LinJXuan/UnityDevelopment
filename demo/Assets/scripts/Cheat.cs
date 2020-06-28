using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    // Start is called before the first frame update
    private Player p;
    private RpgScript player;
    public int playerHp;
    public int playerDefense;
    public int playerAttack;
    void Start()
    {
        p = Player.getInstance ();
        playerHp = p.getHp ();
        playerDefense = p.getDefense ();
        playerAttack = p.getAttack ();
    }

    public void AddHp(){
        playerHp = p.getHp ();
        p.setHp(playerHp + 100);
        playerHp = p.getHp ();
        p.setcurrentHp(playerHp);
    }

    public void AddAttack(){
        playerAttack = p.getAttack ();
        p.setAttack(playerAttack + 20);
    }

    public void AddDefense(){
        playerDefense = p.getDefense ();
        p.setDefense(playerDefense + 20);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
