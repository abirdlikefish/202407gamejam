using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    Idle=0,//待机
    Move,//移动
    Act,//攻击
    Acted,//受击
    Across,//穿过管道
    Split,//拆零件
    Jump,//跳跃
    Fall,//降落
    Dead//死亡
}

public class Statemachine
{
    public Dictionary<StateEnum, State> enum_state = new Dictionary<StateEnum, State>();
    public State currentState;
    public StateEnum currentStateEnum;
    
    
    public void Init()
    {
        enum_state[StateEnum.Idle] = new IdleState();
        enum_state[StateEnum.Move] = new MoveState();

        currentStateEnum = StateEnum.Idle;//开始时进入idle状态
        currentState = enum_state[currentStateEnum];
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

    public void OnChangeState(StateEnum newState)
    {
        State nextState = enum_state[newState];
        
        currentStateEnum = newState;
        
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
}
