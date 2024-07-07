using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Reborn : MonoBehaviour
{
    public void Reborn()
    {
        Game.instance.PlayerReborn();
    }

}
