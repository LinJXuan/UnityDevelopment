using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : PlayerAttribute
{
    private int speed;

    private static BossEnemy instance=new BossEnemy();

    public BossEnemy(int hp,int attack,int range,int speed) : base(hp,attack,range)
    {
        this.speed=speed;
    }
    public BossEnemy(){}
    public static BossEnemy getInstance(){
        return instance;
    }

    public int getSpeed(){
        return this.speed;
    }

    public void setSpeed(int speed){
        this.speed=speed;
    }
}
