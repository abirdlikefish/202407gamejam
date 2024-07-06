using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : SceneObject
{
    private Collider2D _collider;
    private float _openTime;
    public float maxOpenTime;

    private void Awake()
    {
        _collider = transform.GetComponent<Collider2D>();
        _collider.enabled = true;
    }

    private void Update()
    {

        if(_openTime < 0)
        {
            _collider.enabled = true;
        }
        else
        {
            _openTime -= Time.deltaTime;
        }
    }

    public override void Use(GameObject gameObject)
    {
        if (gameObject.tag != "Button") return;
        _openTime = maxOpenTime;
        _collider.enabled = false;
    }

}
