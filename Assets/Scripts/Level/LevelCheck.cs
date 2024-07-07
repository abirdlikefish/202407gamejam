using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

//关卡检查点
public class LevelCheck : MonoBehaviour
{
    [Header("将出现的敌人")]public List<GameObject> enemies;//当前部分将会有的敌人
    //[Header("将出现的零件")]public List<Parts> parts;//当前部分将会有的零件
    public Transform rebornPos;//重生点
    public int id;//当前关卡的id

    public List<GameObject> nowEnemies;//当前关卡生成的敌人

    public Lamp lamp;

    public void LevelInit()
    {
        List<GameObject> temp = new List<GameObject>();
        for (int i = 0; i < enemies.Count; ++i)
        {
            nowEnemies.Add(
                Instantiate(enemies[i], 
                    new Vector3(enemies[i].transform.position.x,enemies[i].transform.position.y,0), 
                    quaternion.identity));
            nowEnemies[i].SetActive(true);
            if (lamp != null)
            {
                if (lamp.enemys.Contains(enemies[i]))
                {
                    temp.Add(nowEnemies[i]);
                }
            }
        }
        if (lamp != null)
        {
            lamp.enemys = temp;
        }
    }
    //关卡重置前将原有的对象清除
    public void LevelClear()
    {
        foreach (var enemy in nowEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        nowEnemies.Clear();
    }
    //离开当前检测点时,如果x坐标大于检测点x坐标,则表示通过
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//玩家穿过检测点
        {
            if (other.transform.position.x > transform.position.x)//向右/向上走
            {
                Game.instance.nowLevel = id;
                Game.instance.EnterLevel(id-1);
            }
            else if (other.transform.position.y > transform.position.y && Game.instance.nowLevel != 10&& Game.instance.nowLevel != 5)
            {
                Game.instance.nowLevel = id;
                Game.instance.EnterLevel(id-1);
            }
            else//向左/向下走
            {
                Game.instance.nowLevel = id - 1;
                Game.instance.EnterLevel(id);
            }
        }
    }
}
