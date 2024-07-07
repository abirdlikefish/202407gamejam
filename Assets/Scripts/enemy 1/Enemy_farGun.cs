using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_farGun : Enemy
{
    public float fireDistance;
    public float fireEndTime;
    public GameObject bullet;
    private GameObject _player;
    private Vector3 _direction;
    private float _waitTime;
    private Transform _gun;
    public float bulletSpeed;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _waitTime = -1;
        _gun = transform.Find("Gun");
        //_offset = new Vector3(0, 1.8f, 0);
    }
    private void Update()
    {

        if(_waitTime < 0)
        {
            if(FindPlayer())
            {
                _waitTime = fireEndTime;
            }

        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }

    private bool FindPlayer()
    {
        if (_player.layer == 13) return false;
        if ((_gun.position - _player.transform.position).magnitude > fireDistance) return false;
        Vector3 midDirection = (_player.transform.position + Vector3.up * 0.3f - _gun.position);
        RaycastHit2D mid = Physics2D.Raycast(_gun.position, midDirection, fireDistance, LayerMask.GetMask("Ground", "Player"));
        Debug.Log(mid.collider.tag);
        if(mid && mid.collider.tag == "Player")
        {
            _direction = midDirection;
//            _gun.LookAt(_gun.transform.position + _direction); 
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            _gun.eulerAngles = new Vector3(0, 0, angle);
            Fire();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Fire()
    {
        GameObject mid = Instantiate(bullet, _gun.transform.position + _direction.normalized * 2, Quaternion.Euler(0, 0, 0));
        mid.GetComponent<Bullet>().Init(_direction.normalized, bulletSpeed);

    }
}
