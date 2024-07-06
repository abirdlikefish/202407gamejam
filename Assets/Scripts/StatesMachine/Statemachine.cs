using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    Hand_1,//一手
    Hand_2,//双手
    Hand_2_Foot_2,//双手双脚
    Hand_1_Foot_2,//单手双脚
    Gun_Hand_1,
    Gun_Hand_2,
    Gun_Hand_1_Foot_2,
    Gun_Hand_2_Foot_2,
}

public class Statemachine
{
    public Dictionary<StateEnum, State> enum_state = new Dictionary<StateEnum, State>();
    public State currentState;
    public StateEnum currentStateEnum;
    public StateEnum lastStateEnum;//上一个状态
    
    public Statemachine(Player player , uint state)
    {
        //Init(player , state);
    }

    public void Init(Player player , uint state)
    {
        //enum_state[StateEnum.Dead] = new DeadState(player,this);
        //enum_state[StateEnum.Hand_0] = new Hand_0_State(player,this);
        enum_state[StateEnum.Hand_1] = new Hand_1_State(player,this);
        enum_state[StateEnum.Hand_2] = new Hand_2_State(player,this);
        enum_state[StateEnum.Hand_1_Foot_2] = new Hand_1_Foot_2_State(player,this);
        enum_state[StateEnum.Hand_2_Foot_2] = new Hand_2_Foot_2_State(player, this);
        enum_state[StateEnum.Gun_Hand_2_Foot_2] = new Gun_Hand_2_Foot_2_State(player, this);
        enum_state[StateEnum.Gun_Hand_1_Foot_2] = new Gun_Hand_1_Foot_2_State(player, this);
        enum_state[StateEnum.Gun_Hand_1] = new Gun_Hand_1_State(player, this);
        enum_state[StateEnum.Gun_Hand_2] = new Gun_Hand_2_State(player, this);

        if (state == 0)
        {
            currentStateEnum = StateEnum.Hand_1;
        }
        else if (state == 1)
        {
            currentStateEnum = StateEnum.Hand_2;
        }
        else if (state == 2)
        {
            currentStateEnum = StateEnum.Hand_1_Foot_2;
        }
        else if (state == 3)
        {
            currentStateEnum = StateEnum.Hand_2_Foot_2;
        }
        else if (state == 4)
        {
            currentStateEnum = StateEnum.Gun_Hand_1;
        }
        else if (state == 5)
        {
            currentStateEnum = StateEnum.Gun_Hand_2;
        }
        else if (state == 6)
        {
            currentStateEnum = StateEnum.Gun_Hand_1_Foot_2;
        }
        else if (state == 7)
        {
            currentStateEnum = StateEnum.Gun_Hand_2_Foot_2;
        }
        currentState = enum_state[currentStateEnum];
        currentState.OnEnter();
        player.ChangeState();

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
    public void OnChangeState(StateEnum newStateEnum)
    {
        State nextState = enum_state[newStateEnum];

        lastStateEnum = currentStateEnum;
        currentStateEnum = newStateEnum;
        
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
    
    
}
