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
    void Start () {
        object1 = GameObject.Find ("Canvas");
        object2 = GameObject.Find ("Bag/Canvas");
        object3 = GameObject.Find ("Pause/Canvas");
        object4 = GameObject.Find ("Attribute/Canvas");
        object1.SetActive (true);
        object2.SetActive (false);
        object3.SetActive (false);
        object4.SetActive (false);
    }

    // Update is called once per frame
    void Update () {

    }
    public void open () {
        object1.SetActive (false);
        object2.SetActive (true);
        object3.SetActive (false);
        object4.SetActive (false);
    }
    public void pause () {
        object1.SetActive (false);
        object2.SetActive (false);
        object3.SetActive (true);
        object4.SetActive (false);
    }
    public void close () {
        object1.SetActive (true);
        object2.SetActive (false);
        object3.SetActive (false);
        object4.SetActive (false);
    }
    public void attribute () {
        object1.SetActive (false);
        object2.SetActive (false);
        object3.SetActive (false);
        object4.SetActive (true);
    }
}