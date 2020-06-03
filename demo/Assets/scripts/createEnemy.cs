using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float totalTime = 3;
    private float dtTime;
    public GameObject gobjL;
    public GameObject gobjR;
    private Vector3 positionL;
    private Vector3 positionR;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        dtTime = totalTime;
        positionR = gobjR.transform.localPosition;
        positionL = gobjL.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        dtTime -= Time.deltaTime;
        if (dtTime < 0&&count<9)
        {
            count++;
            dtTime = totalTime;
            var objR = GameObject.Instantiate(gobjR);
            objR.transform.localPosition = positionR;
            objR.AddComponent<EnemyController>();

            var objL = GameObject.Instantiate(gobjL);
            gobjL.transform.localPosition = positionL;
            gobjL.AddComponent<EnemyController>();
        }
    }
}
