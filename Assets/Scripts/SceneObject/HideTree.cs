using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class HideTree : SceneObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use(GameObject x)
    {
        if (x.tag != "Player") return;
        x.GetComponent<Player>().Hide();
    }
}
