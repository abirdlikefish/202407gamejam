using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    Hand_0 = 0,//没有手,只有一个头
    Hand_1,//一手
    Hand_2,//双手
    Hand_2_Foot_2,//双手双脚
    Hand_1_Foot_2,//单手双脚
    Hand_0_Foot_2,//0手双脚
    Dead//死亡
}

public class Statemachine
{
    public Dictionary<StateEnum, State> enum_state = new Dictionary<StateEnum, State>();
    public State currentState;
    public StateEnum currentStateEnum;
    
    public Statemachine(Player player)
    {
        enum_state[StateEnum.Dead] = new DeadState(player,this);

        currentStateEnum = StateEnum.Hand_0;//开始时进入只有一个头状态
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
