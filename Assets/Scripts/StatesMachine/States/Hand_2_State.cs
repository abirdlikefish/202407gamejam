using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_2_State : State
{
    public Hand_2_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }
    
    public override void OnEnter()
    {
        player.SetParts(1);
        player.AnimationBeg();
    }
    
    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.UseSceneObject();
        if (player.isHide) return;
        player.SetVelocity();//水平移动
        player.Split();
    }
}
