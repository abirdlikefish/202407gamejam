using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : SceneObject
{
    public GameObject[] enemys;
    private void Awake()
    {
        _isOn = false;
    }
    private bool _isOn ;
    public void Init(bool isOn)
    {
        _isOn = isOn;
    }
    public override void Use(GameObject x)
    {
        Debug.Log("lamp is used");
        if (x.tag != "Button") return;
        foreach(GameObject i in enemys)
        {
            i.GetComponent<Enemy>().BeAttracted(transform.position);
        }
        /*
        if(_isOn)
        {
            EventManager.Instance.Event_noise.Invoke(transform.position, 0);
            _isOn = false;
            gameObject.SetActive(false);
        }
        else
        {
            EventManager.Instance.Event_noise.Invoke(transform.position, 0);
            _isOn = true;
            gameObject.SetActive(true);
        }
        */
    }
}
