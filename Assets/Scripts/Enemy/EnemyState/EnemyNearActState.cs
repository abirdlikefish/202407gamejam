using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearActState :EnemyState
{
    public EnemyNearActState(EnemyBase enemy, EnemyStateMachine enemystatemachine) : base(enemy, enemystatemachine)
    {
    }

    public override void OnEnter()
    {
        enemy.clock = 0f;
        enemy.runSpeed = enemy.isLeft * Mathf.Abs(enemy.runSpeed);
    }

    public override void OnUpdate()
    {

        enemy.transform.position += new Vector3(enemy.runSpeed, 0, 0) * Time.deltaTime;

    }
}
