using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_ReturnMain : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}
