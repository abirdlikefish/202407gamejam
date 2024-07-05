using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnUpdate()
    {
        if (Mathf.Abs(player.SetVelocity().x) < float.Epsilon)//当前输入的速度为0,切换状态到idle
        {
            statemachine.OnChangeState(StateEnum.Idle);
            return;
        }

        if (player.IsOnGround())
        {
            statemachine.OnChangeState(StateEnum.Fall);
        }
    }
}
