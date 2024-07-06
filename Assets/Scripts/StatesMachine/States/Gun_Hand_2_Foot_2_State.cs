using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Hand_2_Foot_2_State : State
{
    public Gun_Hand_2_Foot_2_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnEnter()
    {
        player.SetParts(7);
        player.AnimationBeg();
    }
    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.SetVelocity();//Ë®Æ½ÒÆ¶¯
        player.Jump();//ÌøÔ¾
        player.UseSceneObject();
        player.Split();
        player.Attack();
    }
}
