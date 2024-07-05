using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        InitStateMachine();
    }
    void InitStateMachine()
    {
        
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
    public Vector2 GetVector2()
    {
        return rb.velocity;
    }
    public void SetLookDIrection(bool isRight)
    {
        if(isRight)
        {

        }
        else
        {

        }
    }
    public bool IsOnGround()
    {

        return Physics2D.Raycast(transform.position, Vector2.down , 0.1f , LayerMask.GetMask("Ground"));
        
    }
}
