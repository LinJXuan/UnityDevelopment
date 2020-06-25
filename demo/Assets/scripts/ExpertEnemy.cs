using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertEnemy : PlayerAttribute
{
    private int speed;

    private static ExpertEnemy instance=new ExpertEnemy();

    public ExpertEnemy(int hp,int attack,int range,int speed) : base(hp,attack,range)
    {
        this.speed=speed;
    }
    public ExpertEnemy(){}
    public static ExpertEnemy getInstance(){
        return instance;
    }

    public int getSpeed(){
        return this.speed;
    }

    public void setSpeed(int speed){
        this.speed=speed;
    }
}
