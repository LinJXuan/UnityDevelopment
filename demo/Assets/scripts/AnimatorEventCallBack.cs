using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventCallBack : MonoBehaviour
{
    public void DeadFinshCallBack()
    {
        print("DeadFinshCallBack");
    }

    public void AttackOneFinshCallBack()
    {
        print("AttackOneFinshCallBack");
    }

    public void AttackTwoFinshCallBack()
    {
        print("AttackTwoFinshCallBack");
    }

    public void AttackThreeFinshCallBack()
    {
        print("AttackThreeFinshCallBack");
    }

    public void AttackFourFinshCallBack()
    {
        print("AttackFourFinshCallBack");
    }

    public void Hit()
    {
        print("Hit");
    }
}
