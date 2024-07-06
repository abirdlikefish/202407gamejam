using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//近战攻击敌人
public class NearActEnemy : EnemyBase
{
    
    private void Update()
    {
        enemystatemachine.OnUpdate();
        enemystatemachine.OnLateUpdate();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            enemystatemachine.OnChangeState(EnemyStateEnum.NearAct);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemystatemachine.OnChangeState(EnemyStateEnum.Idle);
        }
    }

    public override void ChangeToAct()
    {
        enemystatemachine.OnChangeState(EnemyStateEnum.NearAct);
    }
}
