using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    
    public EnemyIdleState(EnemyBase enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void OnEnter()
    {
        enemy.clock = 0f;
        enemy.transform.localScale = new Vector3(-1f*enemy.transform.localScale.x,1f,1f);//翻转敌人
        enemy.isLeft *= -1;
    }

    public override void OnUpdate()
    {
        enemy.clock += Time.deltaTime;
        if (enemy.clock >= enemy.idleTime)
        {
            enemystatemachine.OnChangeState(EnemyStateEnum.Patrol);
            return;
        }

    }
}
