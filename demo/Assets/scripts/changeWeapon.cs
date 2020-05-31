using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeapon : MonoBehaviour
{
    private int count = 2;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            count++;
            if (count % 2 == 0)
            {
                selectWeapon(0);
            }
            else
            {
                selectWeapon(1);
            }
        }
    }

    void selectWeapon(int index)
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            if (i == index)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
