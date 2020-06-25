using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffShow : MonoBehaviour
{
    // Start is called before the first frame update
    public void click(){
        GameObject.Find ("Canvas2").SetActive(false);
    }
}
