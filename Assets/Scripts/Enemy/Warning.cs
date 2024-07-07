using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public float lastTime;
    public float cntTime;
    private void Awake()
    {
        lastTime = 0.5f;
        cntTime = 0;
        gameObject.SetActive(false);
    }

    public void Beg()
    {
        gameObject.SetActive(true);
        cntTime = lastTime;
    }

    public void Update()
    {
        if(cntTime <= 0)
        {
            gameObject.SetActive(false);
        }
        if(cntTime > 0)
        {
            cntTime -= Time.deltaTime;
        }
    }
}
