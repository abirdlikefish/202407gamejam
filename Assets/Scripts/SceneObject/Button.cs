using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : SceneObject
{
    public Sprite picture_button_on;
    public Sprite picture_button_off;
    public GameObject[] linkedSceneObject;
    private SpriteRenderer _render;
    private bool _state;
    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _state = false;
        _render.sprite = picture_button_off;
    }
    public override void Use(GameObject x)
    {
        if (x.tag != "Player") return;
        if(_state)
        {
            _state = false;
            _render.sprite = picture_button_off;
        }
        else
        {
            _state = true;
            _render.sprite = picture_button_on;
        }
        foreach(GameObject i in linkedSceneObject)
        {
            SceneObject mid = i.GetComponent<SceneObject>();
            mid.Use(gameObject);
        }
    }
}
