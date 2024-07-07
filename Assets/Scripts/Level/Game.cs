using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviourSingleton<Game>
{

    public List<LevelCheck> levels;//所有的关卡检查点
    public int nowLevel = 0;//当前所在关卡的id
    public CameraMove camera;
    public uint playerState;
    public Player player;

    public Canvas deadUI;
    
    //玩家死亡时,将它掉落的零件全部销毁;复活时以最高零件进度复活
    //玩家重生时,先令当前关卡的敌人disactive
    //再将玩家复活到最新达到的关卡重生点,并将对应关卡的敌人active

    public void PlayerReborn()
    {
        //关卡重置
        LevelCheck level = levels[nowLevel];
        //销毁当前部分关卡中的所有敌人
        level.LevelClear();
        //关卡初始化
        level.LevelInit();
        
        //主角重置
        player.Init(playerState);
        player.transform.position = levels[nowLevel].rebornPos.position;
    }

    public void EnterLevel(int lastLevel)
    {
        Debug.Log(nowLevel);
        if (nowLevel == 13)
        {
            camera.nextCheck = levels[13].transform.position;
        }
        else
        {
            camera.nextCheck = levels[nowLevel+1].transform.position;
        }

        if (lastLevel != -1)//将上一关的所有敌人disactive
        {
            LevelCheck last = levels[lastLevel];
            last.LevelClear();
        }
        //将当前关的所有敌人active
        levels[nowLevel].LevelInit();
    }
    //玩家死亡时的行为
    public void PlayerDie(uint playerState)
    {
        this.playerState = playerState;
        //清除所有玩家掉落的零件
        for (int i = 0; i < player.gears.Count; ++i)
        {
            if (player.gears[i] != null)
            {
                Destroy(player.gears[i]);
            }
        }
        player.gears.Clear();
        
        deadUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
