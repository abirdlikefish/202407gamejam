using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : SceneObject
{
    public uint partId;
    public override void Use(GameObject gameObject)
    {
        gameObject.GetComponent<Player>().AddPart(partId);
        Destroy(this.gameObject);
    }
}
