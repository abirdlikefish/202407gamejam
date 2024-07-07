using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CapsuleCollider2D _colliderTall;
    private CircleCollider2D _colliderShort;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Statemachine _stateMachine;
    public GameObject hand;
    public GameObject leg;
    public GameObject bullet;
    private float _speed ;
    public float speed_slow;
    public float speed_fast;
    public float jumpHeight;
    public float bulletSpeed;

    private uint _parts;
    private Transform _gun;

    private void Awake()
    {
        InitComponent();
// test--------------------------------------
        Init(7);
//-------------------------------------------
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
    public void Init(uint state)
    {
        _stateMachine = new Statemachine(this , state);
        _stateMachine.Init(this, state);
    }
    void InitComponent()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _colliderShort = gameObject.GetComponent<CircleCollider2D>();
        _colliderTall = gameObject.GetComponent<CapsuleCollider2D>();
        _animator = gameObject.GetComponent<Animator>();
        _colliderShort.enabled = true;
        _colliderTall.enabled = false;
        _gun = transform.Find("Gun");
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
        //Debug.Log("isJump :" + IsOnGround());
        float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * Physics2D.gravity.y * -1);
        if(IsOnGround() && InputBuffer.Instance.IsJump())
        {
            //Debug.Log("jump");
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
        else
        {

        }
        return _rb.velocity;
    }
    private bool IsOnGround()
    {
//        Debug.Log(Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground")));
        if(((_parts >> 1 ) & 1) == 1)
        {
            return Physics2D.Raycast(transform.position + Vector3.up * 0.2f, Vector2.down , 0.1f , LayerMask.GetMask("Ground"));
        }
        else
        {
            return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        }
    }
    public void AnimationBeg()
    {
        uint x = _parts;
        if(x == 0)
        {
            _animator.SetBool("000" , true);
        }
        else if(x == 1)
        {
            _animator.SetBool("001", true);
        }
        else if (x == 2)
        {
            _animator.SetBool("010", true);
        }
        else if (x == 3)
        {
            _animator.SetBool("011", true);
        }
        else if (x == 4)
        {
            _animator.SetBool("100", true);
        }
        else if (x == 5)
        {
            _animator.SetBool("101", true);
        }
        else if (x == 6)
        {
            _animator.SetBool("110", true);
        }
        else if (x == 7)
        {
            _animator.SetBool("111", true);
        }
    }
    public void SetParts(uint x)
    {
        _parts = x;
        if(((x >> 1) & 1) == 1)
        {
            _speed = speed_fast;
        }
        else
        {
            _speed = speed_slow;
        }

        if(x >= 4)
        {
            _gun.gameObject.SetActive(true);
        }
        else
        {
            _gun.gameObject.SetActive(false);
        }
    }
   
    public bool UseSceneObject()
    {
        if (InputBuffer.Instance.IsUse() == false) return false;
        Collider2D mid = Physics2D.OverlapBox(transform.position + Vector3.up, new Vector2(2, 2) , 0 , LayerMask.GetMask("PlayerParts"));
        if (mid != null)
        {
            if (mid.GetComponent<SceneObject>() == null)
                Debug.Log("SceneObject is null");
            mid.GetComponent<SceneObject>().Use(gameObject);
            return true;
        }
        mid = Physics2D.OverlapCircle(transform.position + Vector3.up, 1.5f, LayerMask.GetMask("SceneObject"));
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
            _gun.localPosition = new Vector2(0.45f, 0.6f);
        }
        else if (_parts == 1)
        {
            _colliderShort.enabled = true;
            _colliderTall.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Hand_2);
            _gun.localPosition = new Vector2(0.45f, 0.6f);
        }
        else if (_parts == 2)
        {
            _colliderShort.enabled = false;
            _colliderTall.enabled = true;
            _stateMachine.OnChangeState(StateEnum.Hand_1_Foot_2);
            _gun.localPosition = new Vector2(0.45f, 2.8f);
        }
        else if (_parts == 3)
        {
            _colliderShort.enabled = false;
            _colliderTall.enabled = true;
            _stateMachine.OnChangeState(StateEnum.Hand_2_Foot_2);
            _gun.localPosition = new Vector2(0.45f, 2.8f);
        }
        else if (_parts == 4)
        {
            _colliderShort.enabled = true;
            _colliderTall.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Gun_Hand_1);
            _gun.localPosition = new Vector2(0.45f, 0.6f);
        }
        else if (_parts == 5)
        {
            _colliderShort.enabled = true;
            _colliderTall.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Gun_Hand_2);
            _gun.localPosition = new Vector2(0.45f, 0.6f);
        }
        else if (_parts == 6)
        {
            _colliderTall.enabled = true;
            _colliderShort.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Gun_Hand_1_Foot_2);
            _gun.localPosition = new Vector2(0.45f, 2.8f);
        }
        else if (_parts == 7)
        {
            _colliderTall.enabled = true;
            _colliderShort.enabled = false;
            _stateMachine.OnChangeState(StateEnum.Gun_Hand_2_Foot_2);
            _gun.localPosition = new Vector2(0.45f, 2.8f);
        }
    }
    public void AddPart(uint x)
    {
//        Debug.Log("addpart");
        _parts = x | _parts;
        ChangeState();
    }

    public void BeAttacked()
    {
        if (_parts == 0)
        {
            Debug.Log("you die");
            Game.instance.PlayerDie();
        }
        else if(_parts == 4)
        {
            Debug.Log("you die");
        }
        else
        {
            if (_parts == 1)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 0;
            }
            else if (_parts == 2)
            {
                Instantiate(leg, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 0;
            }
            else if (_parts == 3)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 2;
            }
            else if (_parts == 5)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 4;
            }
            else if (_parts == 6)
            {
                Instantiate(leg, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 4;
            }
            else if (_parts == 7)
            {
                Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
                _parts = 6;
            }

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
            _rb.velocity = new Vector3(_rb.velocity.x, 5);
            _parts = 0;
        }
        else if (_parts == 3)
        {
            Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
            _parts = 2;
        }
        else if (_parts == 5)
        {
            Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
            _parts = 4;
        }
        else if (_parts == 6)
        {
            Instantiate(leg, transform.position, Quaternion.Euler(Vector3.zero));
            transform.position += Vector3.up * 2;
            _rb.velocity = new Vector3(_rb.velocity.x, 5);
            _parts = 4;
        }
        else if (_parts == 7)
        {
            Instantiate(hand, transform.position, Quaternion.Euler(Vector3.zero));
            _parts = 6;
        }
        ChangeState();
    }

    public void Attack()
    {
        Vector3 midDirection = Mouse.current.position.ReadValue();
        midDirection = Camera.main.ScreenToWorldPoint(midDirection);
        //Debug.Log(midDirection);
        midDirection -= _gun.position;
        float angle = Mathf.Atan2(midDirection.y, midDirection.x) * Mathf.Rad2Deg;
        _gun.eulerAngles = new Vector3(0, 0, angle);
        if (InputBuffer.Instance.IsAttack() == false) return;

        GameObject mid = Instantiate(bullet, _gun.transform.position + midDirection.normalized * 3f , Quaternion.Euler(0, 0, 0));
        mid.GetComponent<Bullet_player>().Init(midDirection.normalized, bulletSpeed);
    }

}

//0.45 2.8  tall
//0.45 0.6 