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

        CheckPlayer();
    }

    private void CheckPlayer()
    {
        //最后一个参数改为玩家所在layer
        //if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, actCheckLen, 1 << 8))
        Debug.Log(Physics.Raycast(transform.position, Vector3.left, actCheckLen));
        if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, actCheckLen, LayerMask.GetMask("Player")))
        {
            Debug.Log("aaaa");
        }
        Debug.DrawLine(transform.position, transform.position + new Vector3(isLeft * actCheckLen, 0, 0));
    }
}
