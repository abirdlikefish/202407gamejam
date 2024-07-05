using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        if (Mathf.Abs(player.SetVelocity().x) > float.Epsilon)//当前输入的速度大于0,切换状态到Move
        {
            statemachine.OnChangeState(StateEnum.Move);
            return;
        }
    }
}
