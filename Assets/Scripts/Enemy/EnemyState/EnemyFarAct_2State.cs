using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarAct_2State : EnemyState
{
    public EnemyFarAct_2State(EnemyBase enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void OnEnter()
    {
        enemy.clock = 0f;
        enemy.Act();
    }

    public override void OnUpdate()
    {
        enemy.clock += Time.deltaTime;
        enemy.CheckPlayer();
        if (enemy.clock >= enemy.actTime)
        {
            enemy.Act();
            enemy.clock = 0f;
        }
    }
}
