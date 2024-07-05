using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearActState :EnemyState
{
    public EnemyNearActState(EnemyBase enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void OnEnter()
    {
        enemy.clock = 0f;
    }
    
    
}
