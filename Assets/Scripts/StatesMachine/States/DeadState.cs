using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public DeadState(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public virtual void OnEnter()//进入死亡状态,根据上一状态选择播放哪一死亡动画
    {
        
    }
}
