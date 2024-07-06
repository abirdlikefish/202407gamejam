using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateEnum
{
    Idle = 0,//站立状态
    Patrol,//巡逻状态
    NearAct,//攻击状态
    FarAct_1,//普通远程攻击
    FarAct_2,//狙击手攻击
    Dead//死亡状态
}

public class EnemyStateMachine
{
    public Dictionary<EnemyStateEnum, EnemyState> enmy_enum_state;
    public EnemyState currentState;
    public EnemyStateEnum currentStateEnum;
    public EnemyStateEnum lastStateEnum;//上一个状态
    
    public EnemyStateMachine(EnemyBase enemy)
    {
        enmy_enum_state = new Dictionary<EnemyStateEnum, EnemyState>();

        enmy_enum_state[EnemyStateEnum.Dead] = new EnemyDeadState(enemy, this);
        enmy_enum_state[EnemyStateEnum.Idle] = new EnemyIdleState(enemy, this);
        enmy_enum_state[EnemyStateEnum.FarAct_1] = new EnemyFarAct_1State(enemy, this);
        enmy_enum_state[EnemyStateEnum.FarAct_2] = new EnemyFarAct_2State(enemy, this);
        enmy_enum_state[EnemyStateEnum.NearAct] = new EnemyNearActState(enemy, this);
        enmy_enum_state[EnemyStateEnum.Patrol] = new EnemyPatrolState(enemy, this);

        currentStateEnum = EnemyStateEnum.Idle;
        currentState = enmy_enum_state[currentStateEnum];
        currentState.OnEnter();
    }
    
    public void OnUpdate()
    {
        currentState.OnUpdate();
    }
    public void OnFixedUpdate()
    {
        currentState.OnFixedUpdate();
    }
    public void OnLateUpdate()
    {
        currentState.OnLateUpdate();
    }
    public void OnChangeState(EnemyStateEnum newStateEnum)
    {
        EnemyState nextState = enmy_enum_state[newStateEnum];

        lastStateEnum = currentStateEnum;
        currentStateEnum = newStateEnum;
        
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
}
