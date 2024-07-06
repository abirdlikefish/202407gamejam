using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : SceneObject
{
    public uint partId;

    float time ;
    public void Awake()
    {
        time = 1f;
    }
    public void Update()
    {
        if(time > 0)
            time -= Time.deltaTime;
    }
    public override void Use(GameObject gameObject)
    {
        if(time > 0)
        {
            return;
        }
        gameObject.GetComponent<Player>().AddPart(partId);
        Destroy(this.gameObject);
    }
}
