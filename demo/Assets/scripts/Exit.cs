using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
    // Start is called before the first frame update
    public void exit () {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}