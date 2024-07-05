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
        _jumpHeight = 3;
    }
    private void Update()
    {
        _stateMachine.OnUpdate();
        _stateMachine.OnLateUpdate();
        Jump();
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
        if(mid == 0)
        {

        }
        else if (mid < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        _rb.velocity = new Vector2(mid * _speed , _rb.velocity.y);
        return _rb.velocity;
    }
    public Vector2 Jump()
    {
        float jumpSpeed = Mathf.Sqrt(2 * _jumpHeight * Physics2D.gravity.y * -1);
        if(IsOnGround() && InputBuffer.Instance.IsJump())
        {
            Debug.Log("jump");
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
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
    public bool UseSceneObject()
    {
        Collider2D mid = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("SceneObject"));
        if(mid == null)
        {
            return false;
        }
        mid.GetComponent<SceneObject>().Use(gameObject);
        return true;
    }
    public bool IsOnGround()
    {

        return Physics2D.Raycast(transform.position, Vector2.down , 0.1f , LayerMask.GetMask("Ground"));
        
    }

    public bool CheckDead()//检查当前是否死亡,若blood小于等于0,则返回true;
    {
        return blood <= 0;
    }

    public void BeAttacked()
    {

    }

}
