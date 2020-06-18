using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhuan : MonoBehaviour
{
    // Start is called before the first frame update
    public  int speed=3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up);
    }
}
