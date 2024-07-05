using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public Player player;

    public State(Player player)
    {
        this.player = player;
    }

    public virtual void OnEnter()
    {
        
    }
    public virtual void OnUpdate()
    {
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
