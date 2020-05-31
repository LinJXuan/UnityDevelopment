using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{
    public float totalTime = 3;
    private float dtTime;
    public GameObject gobj;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        dtTime = totalTime;
        position = gobj.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        dtTime -= Time.deltaTime;
        if (dtTime < 0)
        {
            dtTime = totalTime;
            var obj = GameObject.Instantiate(gobj);
            obj.transform.localPosition = position;
            obj.AddComponent<enemyController>();
        }
    }
}
