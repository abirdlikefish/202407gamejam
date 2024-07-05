using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.Event_noise += Test;
    }

    public void Test(Vector2 a, float b)
    {
        Debug.Log(a);
        Debug.Log(b);
    }


    // Update is called once per frame
    void Update()
    {
        EventManager.Instance.Event_noise.Invoke(new Vector2(Time.time, Time.time), Time.time);
    }
}
