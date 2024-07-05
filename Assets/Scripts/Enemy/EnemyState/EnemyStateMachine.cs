using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyStateEnum
{
    Idle = 0,//站立状态
    Patrol,//巡逻状态
    Act,//攻击状态
    Dead//死亡状态
}

public class EnemyStateMachine
{
    public Dictionary<enemyStateEnum, State> stateMachine;

    public EnemyStateMachine()
    {
        
    }
}
