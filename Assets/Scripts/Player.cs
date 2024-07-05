using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int blood;//剩下可以被击中的次数
    
    private Rigidbody2D _rb;
    private Statemachine _stateMachine;
    private float _speed ;
    private float _jumpHeight;

    private void Awake()
    {
        InitStateMachine();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _speed = 3;
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
        float mid = InputBuffer.Instance.GetInputDirection();
        //Debug.Log(mid);
        _rb.velocity = new Vector2(mid * _speed , _rb.velocity.y);
        return _rb.velocity;
    }
    public Vector2 Jump()
    {
        float jumpSpeed = Mathf.Sqrt(2 * _jumpHeight * Physics2D.gravity.y * -1);
        _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
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

    public bool CheckDead()//检查当前是否死亡,若blood小于等于0,则返回true;
    {
        return blood <= 0;
    }

}
