using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : SceneObject
{
    private void Awake()
    {
        _isOn = false;
    }
    private bool _isOn ;
    public void Init(bool isOn)
    {
        _isOn = isOn;
    }
    public override void Use()
    {
        if(_isOn)
        {
            EventManager.Instance.Event_noise.Invoke(transform.position, 0);
            _isOn = false;
        }
        else
        {
            EventManager.Instance.Event_noise.Invoke(transform.position, 0);
            _isOn = true;
        }
    }
}
