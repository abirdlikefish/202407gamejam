using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int blood;//剩下可以被击中的次数

    private CapsuleCollider2D _colliderTall;
    private CircleCollider2D _colliderShort;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Statemachine _stateMachine;
    public GameObject hand;
    public GameObject leg;
    private float _speed ;
    private float _jumpHeight;
    private uint _parts;

    private void Awake()
    {
        InitComponent();
        InitAttribute();
        InitStateMachine();
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
    void InitComponent()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _colliderShort = gameObject.GetComponent<CircleCollider2D>();
        _colliderTall = gameObject.GetComponent<CapsuleCollider2D>();
        _animator = gameObject.GetComponent<Animator>();
        if (_animator == null)
            Debug.Log("animator is null");
    }
    void InitAttribute()
    {
        _speed = 3;
        _jumpHeight = 3;
        _parts = 0;
    }

    public Vector2 SetVelocity()
    {
        float mid = InputBuffer.Instance.GetInputDirection();
        if(mid == 0)
        {
            _animator.SetBool("IsMove", false);

        }
        else if (mid < 0)
        {
            _animator.SetBool("IsMove", true);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            _animator.SetBool("IsMove", true);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
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
        else
        {

        }
        return _rb.velocity;
    }
    private bool IsOnGround()
    {

        return Physics2D.Raycast(transform.position, Vector2.down , 0.1f , LayerMask.GetMask("Ground"));
    }
    public void AnimationBeg()
    {
        uint x = _parts;
        if(x == 0)
        {
            _animator.SetBool("00" , true);
        }
        else if(x == 1)
        {
            _animator.SetBool("01", true);
        }
        else if (x == 2)
        {
            _animator.SetBool("10", true);
        }
        else if (x == 3)
        {
            _animator.SetBool("11", true);
        }
    }
    public void SetParts(uint x)
    {
        _parts = x;
    }
   
    public bool UseSceneObject()
    {
        if (InputBuffer.Instance.IsUse() == false) return false;
        Collider2D mid = Physics2D.OverlapBox(transform.position, new Vector2(10, 1) , 0 , LayerMask.GetMask("PlayerParts"));
        //Debug.Log("layermaske = " + LayerMask.GetMask("PlayerParts"));
        if (mid != null)
        {
            //Debug.Log(mid.name + mid.gameObject.layer);
            if (mid.GetComponent<SceneObject>() == null)
                Debug.Log("SceneObject is null");
            mid.GetComponent<SceneObject>().Use(gameObject);
            return true;
        }
        mid = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("SceneObject"));
        if (mid != null)
        {
            mid.GetComponent<SceneObject>().Use(gameObject);
            return true;
        }
        return false;

    }

    public void ChangeState()
    {
        if (_parts == 0)
        {
            _colliderShort.enabled = true;
            _colliderTall.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Hand_1);
        }
        else if (_parts == 1)
        {
            _colliderShort.enabled = true;
            _colliderTall.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Hand_2);
        }
        else if (_parts == 2)
        {
            _colliderShort.enabled = false;
            _colliderTall.enabled = true;
            _stateMachine.OnChangeState(StateEnum.Hand_1_Foot_2);
        }
        else if (_parts == 3)
        {
            _colliderShort.enabled = false;
            _colliderTall.enabled = true;
            _stateMachine.OnChangeState(StateEnum.Hand_2_Foot_2);
        }
    }
    public void AddPart(uint x)
    {
        Debug.Log("addpart");
        _parts = x | _parts;
        ChangeState();
    }

    public void BeAttacked()
    {
        if (_parts == 0)
        {
            Debug.Log("you die");
        }
        else
        {
            if (_parts == 1)
                _parts = 0;
            else if (_parts == 2)
                _parts = 0;
            else if (_parts == 3)
                _parts = 2;
        }
        ChangeState();

    }
     public void Split()
        {
            if (InputBuffer.Instance.IsSplit() == false || _parts == 0) return;
        Debug.Log(_parts);

            if (_parts == 1)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 0;
            }
            else if (_parts == 2)
            {
                Instantiate(leg, transform.position, Quaternion.Euler(Vector3.zero));
                transform.position += Vector3.up * 2;
                _parts = 0;
            }
            else if (_parts == 3)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 2;
            }
            ChangeState();
        }

}
