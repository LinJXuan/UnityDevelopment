using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public float totalTime = 3;
    private float dtTime;
    //public GameObject gobjL;
    public GameObject gobjR;
    public GameObject enemyPosition;
    private Vector3 positionL;
    private Vector3 positionR;
    private Quaternion rotationL;
    private Quaternion rotationR;
    public int enemyCount = 10;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        dtTime = totalTime;
        positionR = enemyPosition.transform.localPosition;
        rotationR = enemyPosition.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        dtTime -= Time.deltaTime;
        if (dtTime < 0&&count< enemyCount)
        {
            count++;
            dtTime = totalTime;

            positionL = positionR;
            positionL.x = -positionR.x;
            rotationL = rotationR;
            Instantiate(gobjR, positionR, rotationR);
            Instantiate(gobjR, positionL, rotationL);
            print("======= create enemy ======");
        }
    }
}
