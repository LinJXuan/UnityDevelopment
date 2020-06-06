﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffShow : MonoBehaviour
{
    public GameObject start;
    public GameObject map;
    public GameObject login;
    
    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
        start.SetActive(false);
        login.GetComponent<Button>().onClick.AddListener(offshow);
    }
    void offshow()
    {
        start.SetActive(true);
        map.SetActive(true);
        login.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}