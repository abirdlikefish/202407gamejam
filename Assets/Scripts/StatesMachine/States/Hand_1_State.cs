using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_1_State : State
{
    public Hand_1_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }
    
    public override void OnEnter()
    {
        player.SetParts(0);
        player.AnimationBeg();
    }
    
    public override void OnUpdate()
    {
        //base.OnUpdate();

        player.SetVelocity();
        player.UseSceneObject();
        player.Split();
    }
}
