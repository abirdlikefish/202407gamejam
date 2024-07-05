using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_0_State : State
{
    public Hand_0_State(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }

    public override void OnEnter()
    {
        player.blood = 1;
    }
}
