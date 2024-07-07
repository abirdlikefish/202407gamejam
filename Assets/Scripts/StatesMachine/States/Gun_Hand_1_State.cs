using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Hand_1_State : State
{
    public Gun_Hand_1_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnEnter()
    {
        player.SetParts(4);
        player.AnimationBeg();
    }
    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.UseSceneObject();
        if (player.isHide) return;
        player.SetVelocity();//Ë®Æ½ÒÆ¶¯
        player.Attack();
    }
}
