using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector3 position_beg;
    public Vector3 position_end;
    public Vector3 detectPosition;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        if(IsUse())
        {
            if (Mathf.Abs(transform.position.y - position_end.y) < 0.1) return;
            float midy = (position_end.y - transform.position.y > 0 ? 1 : -1) * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + midy, transform.position.z);
        }
        else
        {
            if (Mathf.Abs(transform.position.y - position_beg.y) < 0.1) return;
            float midy = (position_beg.y - transform.position.y > 0 ? 1 : -1) * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + midy, transform.position.z);
        }
    }
    private bool IsUse()
    {
        return Physics2D.OverlapBox(detectPosition + transform.position, new Vector2(0.5f,1), 0, LayerMask.GetMask("Player", "Enemy", "PlayerParts"));
    }
}
