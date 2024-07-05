using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可以跳,可以跑
public class Hand_1_Foot_2_State : State
{
    public Hand_1_Foot_2_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }
    
    public override void OnEnter()
    {
        player.blood = 3;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        player.SetVelocity();//水平移动
        player.Jump();//跳跃
        //场景交互检查
    }
}
