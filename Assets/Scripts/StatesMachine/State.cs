using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public Player player;
    public Statemachine statemachine;

    public State(Player player,Statemachine statemachine)
    {
        this.player = player;
        this.statemachine = statemachine;
    }
    public virtual void OnEnter()
    {
        
    }
    public virtual void OnUpdate()
    {
//        if (player.CheckDead())
//        {
//            statemachine.OnChangeState(StateEnum.Dead);
//        }
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
