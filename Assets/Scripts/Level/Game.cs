using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviourSingleton<Game>
{

    public List<LevelCheck> levels;//所有的关卡检查点
    public int nowLevel = 0;//当前所在关卡的id
    public CameraMove camera;
    
    //玩家死亡时,将它掉落的零件全部销毁;复活时以最高零件进度复活
    //玩家重生时,先令当前关卡的敌人disactive
    //再将玩家复活到最新达到的关卡重生点,并将对应关卡的敌人active

    public void PlayerReborn()
    {
        LevelCheck level = levels[nowLevel];
        //销毁自己掉落的全部零件

        //销毁当前部分关卡中的所有敌人
        level.LevelClear();
        //关卡初始化
        level.LevelInit();
    }

    public void EnterLevel()
    {
        Debug.Log("aaaaa" +
                  "");
        camera.nextCheck = levels[nowLevel+1].transform.position;
    }

    public void PlayerDie()
    {
        
    }
}
