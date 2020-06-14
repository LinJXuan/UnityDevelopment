using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBag : MonoBehaviour {
    // Start is called before the first frame update
    public static GameObject object1;
    public static GameObject object2;
    void Start () {
        object1 = GameObject.Find ("Canvas");
        object2 = GameObject.Find ("Bag/Canvas");
        object1.SetActive (true);
        object2.SetActive (false);
    }

    // Update is called once per frame
    void Update () {

    }
    public void open () {
        object1.SetActive (false);
        object2.SetActive (true);

    }
    public void close () {
        object1.SetActive (true);
        object2.SetActive (false);
    }
}