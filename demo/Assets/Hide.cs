
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnObj;
    public GameObject map;
    public GameObject btnStart;
    public GameObject btnLogin;
    Button btn;
    bool isshow = false;
    void Start()
    {
        map.SetActive(isshow);
        btnStart.SetActive(isshow);
        btnLogin.SetActive(!isshow);
        btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            isshow = !isshow;
            map.SetActive(isshow);
            btnStart.SetActive(isshow);
            btnLogin.SetActive(!isshow);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
