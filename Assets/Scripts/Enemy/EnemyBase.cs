using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int blood;//血量
    public float idleTime;//站立时间
    public float patroTime;//巡逻时间
    public float leaveActTime;//离开攻击状态时间
    public float actCheckLen;//用于检测玩家的射线长度
    public Transform target;//当前敌人的攻击目标

    public int isLeft = 1;
    //[HideInInspector]public float clock = 0f;
    public float clock = 0f;
    
    public float moveSpeed;//水平移动速度

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
}
