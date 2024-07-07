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
        player.SetParts(2);
        player.AnimationBeg();
    }

    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.UseSceneObject();
        if (player.isHide) return;
        player.SetVelocity();//水平移动
        player.Jump();//跳跃
        player.Split();
    }
}
