using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertEnemy : PlayerAttribute
{
    private int speed;

    private static ExpertEnemy instance=new ExpertEnemy(80,15,3,2);

    public ExpertEnemy(int hp,int attack,int range,int speed) : base(hp,attack,range)
    {
        this.speed=speed;
    }

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
