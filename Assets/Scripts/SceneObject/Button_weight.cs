using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button_weight : SceneObject
{
    public GameObject[] linkedSceneObject;
    public Sprite picture_button_on;
    public Sprite picture_button_off;
    private SpriteRenderer _render;
    private void Awake()
    {
        _render = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(IsUse())
        {
            _render.sprite = picture_button_on ;
            foreach (GameObject i in linkedSceneObject)
            {
                SceneObject mid = i.GetComponent<SceneObject>();
                mid.Use(gameObject);
            }
        }
        else
        {
            _render.sprite = picture_button_off;

        }
    }

    private bool IsUse()
    {
        return Physics2D.OverlapBox(transform.position + Vector3.up * 0.5f, new Vector2(1,0.5f ) , 0 , LayerMask.GetMask("Player" , "Enemy" , "PlayerParts"));
    }
}
