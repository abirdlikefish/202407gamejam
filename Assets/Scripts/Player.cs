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
        _rb = gameObject.GetComponent<Rigidbody2D>();
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
        Debug.Log("ask for move");
        float mid = InputBuffer.Instance.GetInputDirection();
        _rb.velocity = new Vector2(mid* _speed , _rb.velocity.y);
        return _rb.velocity;
    }
    public Vector2 Jump()
    {
        return default;
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
    public bool UseSceneObject()
    {
        Collider2D mid = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("SceneObject"));
        if(mid == null)
        {
            return false;
        }
        mid.GetComponent<SceneObject>().Use();
        return true;
    }
}
