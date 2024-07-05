using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public DeadState(Player player, Statemachine statemachine) : base(player, statemachine)
    {
    }
}
