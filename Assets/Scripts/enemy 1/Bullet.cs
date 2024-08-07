using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[HideInInspector] public Vector3 velocity;//子弹的飞行速度
    //[Header("子弹的飞行速率")] public float speed;//子弹的飞行速率
    private float speed;
    [Header("子弹的存活时间")] public float lifeTime;//子弹的存活时间,超过后销毁自己

    private float clock;
    private Vector2 _direction;

    private void Update()
    {
        Vector2 mid = _direction * speed * Time.deltaTime;
        transform.position += new Vector3(mid.x , mid.y , 0);
        clock += Time.deltaTime;

        if (clock >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

//    private void OnTriggerEnter2D(Collider2D other)
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.name + " " + other.tag);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().BeAttacked();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().BeAttacked();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }

    public void Init(Vector2 direction, float speed)
    {
        this.speed = speed;
        this._direction = direction;
    }
}
