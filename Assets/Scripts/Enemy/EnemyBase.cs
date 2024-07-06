using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int blood;//血量
    public float idleTime;//站立时间
    public float patroTime;//巡逻时间
    public float actCheckLen;//用于检测玩家的射线长度
    public Transform target;//当前敌人的攻击目标
    public float actTime;//攻击时间间隔
    public float buttleSpeed;//子弹飞行速度
    
    public int isLeft = 1;
    //[HideInInspector]public float clock = 0f;
    public float clock = 0f;
    
    public float moveSpeed;//水平移动速度-巡逻时
    public float runSpeed;//追击主角时速度

    public EnemyStateMachine enemystatemachine;
    public void Awake()
    {
        enemystatemachine = new EnemyStateMachine(this);
    }
    
    public virtual bool CheckDead()
    {
        return blood <= 0;
    }
    public virtual bool CheckPlayer()
    {
        return default;
    }

    public virtual void ChangeToAct()
    {
        
    }
    public virtual void Act()//敌人进行攻击
    {}
}
