using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : PlayerAttribute
{
    private int speed;

    private static NormalEnemy instance=new NormalEnemy();

    public NormalEnemy(int hp,int attack,int range,int speed) : base(hp,attack,range)
    {
        this.speed=speed;
    }
    public NormalEnemy(){}

    public static NormalEnemy getInstance(){
        return instance;
    }

    public int getSpeed(){
        return this.speed;
    }

    public void setSpeed(int speed){
        this.speed=speed;
    }
}
