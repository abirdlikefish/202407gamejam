using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Hand_1_Foot_2_State : State
{
    public Gun_Hand_1_Foot_2_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnEnter()
    {
        player.SetParts(6);
        player.AnimationBeg();
    }
    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.SetVelocity();//ˮƽ�ƶ�
        player.Jump();//��Ծ
        player.UseSceneObject();
        player.Split();
        player.Attack();
    }
}
