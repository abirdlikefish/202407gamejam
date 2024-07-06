using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    public EnemyPatrolState(EnemyBase enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void OnEnter()
    {
        enemy.clock = 0f;
    }

    public override void OnUpdate()
    {
        enemy.clock += Time.deltaTime;
        if (enemy.clock >= enemy.patroTime)
        {
            enemystatemachine.OnChangeState(EnemyStateEnum.Idle);
            return;
        }
        enemy.transform.position += new Vector3(enemy.isLeft * enemy.moveSpeed * Time.deltaTime, 0, 0);
    }

}
