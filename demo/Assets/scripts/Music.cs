using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgm;
    void Start()
    {
        bgm.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
