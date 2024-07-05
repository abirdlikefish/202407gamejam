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

    public override bool CheckPlayer()
    {
        //Debug.DrawLine(transform.position, transform.position + new Vector3(isLeft * actCheckLen, 0, 0));
        
        //最后一个参数改为玩家所在layer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, actCheckLen, 1 << 8);
        if (hit)
        {
            target = hit.transform;
            return true;
        }
        return false;
    }
}
