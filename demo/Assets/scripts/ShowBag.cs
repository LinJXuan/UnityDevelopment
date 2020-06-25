using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBag : MonoBehaviour {
    // Start is called before the first frame update
    public static GameObject object1;
    public static GameObject object2;
    public static GameObject object3;
    public static GameObject object4;
    public static GameObject object5;
    private Player p;
    private int levelPoint; //升级点数
    private int count;
    void Start () {
        object1 = GameObject.Find ("Canvas1");
        object2 = GameObject.Find ("Bag/Canvas");
        object3 = GameObject.Find ("Pause/Canvas");
        object4 = GameObject.Find ("Attribute/Canvas");
        object5 = GameObject.Find ("Attribute/Canvas/NoAdd");
        object1.SetActive (true);
        object2.SetActive (false);
        object3.SetActive (false);
        object4.SetActive (false);
        object5.SetActive (false);
        p = Player.getInstance ();
        levelPoint = p.getlevelPoint ();
        count = PlayerHealth.numberOfEnemy;
    }

    // Update is called once per frame
    void Update () {
        count = PlayerHealth.numberOfEnemy;
        if (count % 6 == 4) {
            AddlevelPoint ();
            attribute ();
            PlayerHealth.numberOfEnemy++;
        }
    }
    public void open () {
        levelPoint = p.getlevelPoint ();
        if (levelPoint == 0) {
            object1.SetActive (false);
            object2.SetActive (true);
            object3.SetActive (false);
            object4.SetActive (false);
            object5.SetActive (false);
            Time.timeScale = 0;
        } else {
            object1.SetActive (false);
            object2.SetActive (false);
            object3.SetActive (false);
            object4.SetActive (true);
            object5.SetActive (true);
            Time.timeScale = 0;
        }
    }
    public void pause () {
        object1.SetActive (true);
        object2.SetActive (false);
        object3.SetActive (true);
        object4.SetActive (false);
        object5.SetActive (false);
        Time.timeScale = 0;
    }
    public void close () {
        levelPoint = p.getlevelPoint ();
        if (levelPoint == 0) {
            object1.SetActive (true);
            object2.SetActive (false);
            object3.SetActive (false);
            object4.SetActive (false);
            object5.SetActive (false);
            Time.timeScale = 1;
        } else {
            object1.SetActive (false);
            object2.SetActive (false);
            object3.SetActive (false);
            object4.SetActive (true);
            object5.SetActive (true);
            Time.timeScale = 0;
        }
    }
    public void attribute () {
        object1.SetActive (false);
        object2.SetActive (false);
        object3.SetActive (false);
        object4.SetActive (true);
        object5.SetActive (false);
        Time.timeScale = 0;
    }
    private void AddlevelPoint () {

        levelPoint = p.getlevelPoint ();

        levelPoint += 1;
        print ("升级点数+1");
        p.setlevelPoint (levelPoint); //写入升级点数

    }
}