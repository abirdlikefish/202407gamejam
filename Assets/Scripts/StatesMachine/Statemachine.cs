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
    
    public Statemachine(Player player)
    {
        enum_state[StateEnum.Idle] = new IdleState(player,this);
        enum_state[StateEnum.Move] = new MoveState(player,this);
        enum_state[StateEnum.Act] = new ActState(player,this);
        enum_state[StateEnum.Acted] = new ActedState(player,this);
        enum_state[StateEnum.Across] = new AcrossState(player,this);
        enum_state[StateEnum.Split] = new SplitState(player,this);
        enum_state[StateEnum.Jump] = new JumpState(player,this);
        enum_state[StateEnum.Fall] = new FallState(player,this);
        enum_state[StateEnum.Dead] = new DeadState(player,this);

        currentStateEnum = StateEnum.Idle;//开始时进入idle状态
        currentState = enum_state[currentStateEnum];
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

    public void OnChangeState(StateEnum newState)
    {
        State nextState = enum_state[newState];
        
        currentStateEnum = newState;
        
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
}
