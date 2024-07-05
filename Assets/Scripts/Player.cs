using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Statemachine _stateMachine;
    private float _speed ;

    private void Awake()
    {
        InitStateMachine();
        _rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _stateMachine.OnUpdate();
        _stateMachine.OnLateUpdate();
    }
    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
    }
    void InitStateMachine()
    {
        _stateMachine = new Statemachine(this);
    }

    public Vector2 SetVelocity()
    {
        Vector2 mid = InputBuffer.Instance.GetInputDirection();
        _rb.velocity = new Vector2(mid.x * _speed , _rb.velocity.y);
        return _rb.velocity;
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
