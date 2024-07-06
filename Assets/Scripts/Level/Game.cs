using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; set; }

    public List<LevelCheck> levels;//所有的关卡检查点
    public int nowLevel = 0;//当前所在关卡的id

    [HideInInspector]public List<GameObject> splitParts;//主角受伤掉落的零件
    
    //玩家死亡时,将它掉落的零件全部销毁;复活时以最高零件进度复活
    //玩家重生时,先令当前关卡的敌人disactive
    //再将玩家复活到最新达到的关卡重生点,并将对应关卡的敌人active

    public void PlayerReborn()
    {
        
    }

    public void PlayerDie()
    {
        
    }
}
