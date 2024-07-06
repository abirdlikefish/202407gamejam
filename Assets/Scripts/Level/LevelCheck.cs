using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//关卡检查点
public class LevelCheck : MonoBehaviour
{
    [Header("将出现的敌人")]public List<Transform> enemies;//当前部分将会有的敌人
    [Header("将出现的零件")]public List<Parts> parts;//当前部分将会有的零件
    public Transform rebornPos;//重生点
    public int id;//当前关卡的id

    //离开当前检测点时,如果x坐标大于检测点x坐标,则表示通过
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//玩家穿过检测点
        {
            if (other.transform.position.x > transform.position.x)
            {
                Game.Instance.nowLevel = id;
            }
            else
            {
                Game.Instance.nowLevel = id - 1;
            }
        }
    }
}
