using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sword: Enemy
{
    private Vector2 position;
    public float speed;
    public float attack_endTime;
    public float attack_distance;
    public float findDistance;
    private float _attackTime = -1;
    private int _attackState;
    private int _moveState;
    private Animator _animator;
    //private int _moveState;

    //0 findlight   1 findposition      2 static
    private Vector3 _target;
    private int _faceDirection;
    public bool isFaceRight;
    private GameObject _player;

    public float waitTime_lamp;
    private float haveWaitTime;
    private bool isWaitLamp;
    private void Start()
    {
        haveWaitTime = 0;
        isWaitLamp = false;

        position = transform.position;
        _moveState = 2;
        _target = position;
        _attackState = 0;
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
        //_faceDirection = 1;
        _animator = transform.GetComponent<Animator>();
        Animation_idleBeg();
    }
    private void Update()
    {
        if (_attackState == 0)
        {
            if(isWaitLamp&&haveWaitTime <waitTime_lamp)
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
                    }
                    else if (_moveState == 0)
                    {
                        if(isWaitLamp == false)
                        {
                            haveWaitTime = 0;
                            isWaitLamp = true;
                            return;
                        }
                        _target = position;
                        _moveState = 1;
                        isWaitLamp = false;
                    }
                }
            }
            FindPlayer();
        }
        else if (_attackState == 1)
        {
            FindPlayer();
            _faceDirection = _target.x - transform.position.x > 0 ? 1 : -1;
            transform.position += new Vector3(_faceDirection * Time.deltaTime * new Vector2(speed, 0).x, 0, 0);
            if (Mathf.Abs(_target.x - transform.position.x) < attack_distance)
            {
                Attack();
                _attackState = 2;
                _attackTime = attack_endTime;
            }
        }
        else
        {
            if (_attackTime < 0)
            {
                //_attackState = 0;
                //_target = position;
                _moveState = 1;
                Animation_runBeg();
                FindPlayer();
            }
            _attackTime -= Time.deltaTime;
        }
    }
    private void FindPlayer()
    {
        RaycastHit2D mid = Physics2D.Raycast(transform.position + Vector3.up, new Vector2(_faceDirection, 0), findDistance, LayerMask.GetMask("Player"));
        if (mid)
        {
            if(_attackState == 0)
            {
                Animation_runBeg();
            }
            _attackState = 1;
            _target = mid.point;
            _player = mid.collider.gameObject;

            isWaitLamp = false;
        }
        else if(_moveState == 0)
        {

        }
        else if(_moveState == 1)
        {
            _attackState = 0;
            _target = position;
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
    private void Animation_attackBeg()
    {
        _animator.SetBool("Trigger_attack", true);
    }
    private void Attack()
    {
        Collider2D[] mid = Physics2D.OverlapBoxAll(transform.position + new Vector3(_faceDirection, 1, 0), new Vector2(2, 2), 0, LayerMask.GetMask("Player", "Enemy"));
        foreach(Collider2D i in mid)
        {
            if (i.gameObject == this.gameObject) continue;
            if(i.tag == "Player")
            {
                i.GetComponent<Player>().BeAttacked();
            }
            else if(i.tag == "Enemy")
            {
                i.GetComponent<Enemy>().BeAttacked();
            }
            else
            {
                Debug.Log("error tag!!!");
            }
        }
        //_player.GetComponent<Player>().BeAttacked();
        Animation_attackBeg();
    }
    public override void BeAttacked()
    {
        Destroy(gameObject);
    }
    public override void BeAttracted(Vector3 position)
    {
        Debug.Log("be attracted");
        _moveState = 0;
        _target = position;
        Animation_runBeg();
    }
}
