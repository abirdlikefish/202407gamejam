using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_gun_static : Enemy
{
    private Vector2 position;
    public float speed;
    public float fire_begTime;
    public float fire_endTime;
    public float findDistance;
    public GameObject bullet;
    private float _fireTime = -1;
    private int _fireState;
    private int _moveState;
    //0 findlight   1 findposition      2 static
    private Vector3 _target;
    private int _faceDirection;
    private Animator _animator;
    public float bulletSpeed;
    public bool isFaceRight;


    public float waitTime_lamp;
    private float haveWaitTime;
    private bool isWaitLamp;

    private Warning warning;

    private void Start()
    {
        isWaitLamp = false;
        haveWaitTime = 0;

        position = transform.position;
        _moveState = 2;
        _target = position;
        _fireState = 0;
        if(isFaceRight)
        {
            _faceDirection = 1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _faceDirection = -1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        _animator = transform.GetComponent<Animator>();
        Animation_idleBeg();

        warning = transform.Find("Warning").GetComponent<Warning>();
    }
    private void Update()
    {
        if (_fireState == 0)
        {
            if (isWaitLamp && haveWaitTime < waitTime_lamp)
            {
                haveWaitTime += Time.deltaTime;
                FindPlayer();
                return;
            }
            if (_moveState != 2)
            {
                _faceDirection = _target.x - transform.position.x > 0 ? 1 : -1;
                transform.position += new Vector3(_faceDirection * Time.deltaTime * new Vector2(speed, 0).x, 0, 0);
                if (_faceDirection == 1)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (Mathf.Abs(_target.x - transform.position.x) < 0.1)
                {
                    if (_moveState == 1)
                    {
                        _target = position;
                        _moveState = 2;
                        Animation_idleBeg();
                        if (isFaceRight)
                        {
                            _faceDirection = 1;
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                        else
                        {
                            _faceDirection = -1;
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                        }
                    }
                    else if(_moveState == 0)
                    {
                        if(isWaitLamp == false)
                        {
                            isWaitLamp = true;
                            haveWaitTime = 0;
                            Animation_idleBeg();
                            return;
                        }
                        Animation_runBeg();
                        _target = position;
                        _moveState = 1;
                        isWaitLamp = false;
                    }
                }
            }
            FindPlayer();
        }
        else if (_fireState == 1)
        {
            if (_fireTime < 0)
            {
                _fireTime = fire_endTime;
                Fire();
                _fireState = 2;
            }
            _fireTime -= Time.deltaTime;
        }
        else
        {
            if (_fireTime < 0)
            {
                _fireState = 0;
                _target = position;
                if (Mathf.Abs(_target.x - transform.position.x) < 0.1)
                {
                    Animation_idleBeg();
                    _moveState = 2;
                }
                else
                {
                    Animation_runBeg();
                    _moveState = 1;

                }
            }
            _fireTime -= Time.deltaTime;
        }
    }
    private void Animation_runBeg()
    {
        _animator.SetBool("Trigger_move", true);
    }
    private void Animation_idleBeg()
    {
        _animator.SetBool("Trigger_idle", true);
    }
    private void Animation_fireBeg()
    {
        _animator.SetBool("Trigger_idle", true);
    }
    private void FindPlayer()
    {
        if (Physics2D.Raycast(transform.position + Vector3.up, new Vector2(_faceDirection, 0), findDistance, LayerMask.GetMask("Player")))
        {
            isWaitLamp = false;

            _fireState = 1;
            _fireTime = fire_begTime;
            Animation_fireBeg();
            warning.Beg();
        }
    }
    private void Fire()
    {
        GameObject mid = Instantiate(bullet, transform.position + new Vector3(_faceDirection, 0, 0) + Vector3.up * 1.5f, Quaternion.Euler(0, 0, 0));
        mid.GetComponent<Bullet>().Init(new Vector2(_faceDirection, 0).normalized, bulletSpeed);
    }
    public override void BeAttacked()
    {
        Destroy(gameObject);
    }
    public override void BeAttracted(Vector3 position)
    {
        _moveState = 0;
        _target = position;
        Animation_runBeg();
    }
}
