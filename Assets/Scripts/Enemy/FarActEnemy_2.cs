using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//狙击手
public class FarActEnemy_2 : EnemyBase
{
    public Transform buttle;
    public LineRenderer line;
    public EdgeCollider2D actRange;

    public bool lookPlayer =false;//当前是否瞄准主角

    private void Start()
    {
        line = transform.GetComponent<LineRenderer>();
        line.positionCount = 0;
    }
    
    private void Update()
    {
        enemystatemachine.OnUpdate();
        enemystatemachine.OnLateUpdate();
    }

    public override bool CheckPlayer()
    {
        line.positionCount = 2;
        line.SetPosition(0,transform.position);
        line.SetPosition(1,target.position);
        return true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            enemystatemachine.OnChangeState(EnemyStateEnum.FarAct_2);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            line.positionCount = 0;
            enemystatemachine.OnChangeState(EnemyStateEnum.Idle);
        }
    }

    public override void Act()
    {
        
        GameObject.Instantiate(buttle,transform.position+new Vector3(0f,1f,0f),Quaternion.identity).GetComponent<Buttle>().Init(target.position,buttleSpeed);
    }

    public override void ChangeToAct()
    {
        enemystatemachine.OnChangeState(EnemyStateEnum.FarAct_2);
    }
}
