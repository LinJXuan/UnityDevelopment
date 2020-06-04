using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    private int point = 0;
    // Start is called before the first frame update
    private static Statistic instance = new Statistic();
    private Statistic() { }
    public static Statistic getInstance()
    {
        return instance;
    }
    public void setPoint(int point)
    {
        this.point += point;
    }

    public int getPoint()
    {
        return this.point;
    }
}
