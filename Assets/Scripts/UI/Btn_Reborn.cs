using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Reborn : MonoBehaviour
{
    private void OnMouseDown()
    {
        Game.instance.PlayerReborn();
        Time.timeScale = 1f;
        transform.parent.gameObject.SetActive(false);
    }
}
