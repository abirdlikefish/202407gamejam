using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_2_Foot_2_State : State
{
    public Hand_2_Foot_2_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }
    
    public override void OnEnter()
    {
        player.blood = 4;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        player.SetVelocity();//水平移动
        player.Jump();//跳跃
        //场景交互检查
    }
}
