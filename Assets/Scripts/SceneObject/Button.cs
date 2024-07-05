using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : SceneObject
{
    public GameObject[] linkedSceneObject;
    private void Awake()
    {
        
    }
    public override void Use(GameObject x)
    {
        if (x.tag != "Player") return;
        foreach(GameObject i in linkedSceneObject)
        {
            SceneObject mid = i.GetComponent<SceneObject>();
            mid.Use(gameObject);
        }
    }
}
