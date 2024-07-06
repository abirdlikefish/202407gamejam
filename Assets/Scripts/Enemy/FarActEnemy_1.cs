using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//远程攻击敌人
public class FarActEnemy_1 : EnemyBase
{
    public Transform buttle;
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
            enemystatemachine.OnChangeState(EnemyStateEnum.FarAct_1);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemystatemachine.OnChangeState(EnemyStateEnum.Idle);
        }
    }

    public override void Act()
    {
        Debug.Log("aaaa");
        GameObject.Instantiate(buttle,transform.position,Quaternion.identity).GetComponent<Buttle>().Init(target.position,buttleSpeed);
    }
}
