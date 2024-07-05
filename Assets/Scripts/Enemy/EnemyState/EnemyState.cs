using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public EnemyBase enemy;
    public EnemyStateMachine enemystatemachine;

    public EnemyState(EnemyBase enemy,EnemyStateMachine enemystatemachine)
    {
        this.enemy = enemy;
        this.enemystatemachine = enemystatemachine;
    }

    public virtual void OnEnter()
    {
        
    }
    public virtual void OnUpdate()
    {
        if (enemy.CheckDead())
        {
            enemystatemachine.OnChangeState(EnemyStateEnum.Dead);
        }
    }
    public virtual void OnFixedUpdate()
    {
    }
    public virtual void OnLateUpdate()
    {
    }
    public virtual void OnExit()
    {
    }
}
