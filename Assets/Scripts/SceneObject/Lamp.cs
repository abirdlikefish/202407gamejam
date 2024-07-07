using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : SceneObject
{
    public GameObject[] enemys;
    [SerializeField]public Sprite picture_on;
    public Sprite picture_off;
    private SpriteRenderer _render;
    private void Awake()
    {
        _isOn = true;
        _render = transform.GetComponent<SpriteRenderer>();
        _render.sprite = picture_on;
    }
    private bool _isOn ;
    
    
    public override void Use(GameObject x)
    {
        Debug.Log("lamp is used");
        if (x.tag != "Button") return;
        foreach(GameObject i in enemys)
        {
            i.GetComponent<Enemy>().BeAttracted(transform.position);
        }

        if(_isOn)
        {
            _isOn = false;
            _render.sprite = picture_off;
        }
        else
        {
            _isOn = true;
            _render.sprite = picture_on;
        }

    }
}
