using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle : MonoBehaviour
{
    [HideInInspector]public Vector3 velocity;//子弹的飞行速度
    [Header("子弹的飞行速率")]public float speed;//子弹的飞行速率
    [Header("子弹的存活时间")]public float lifeTime;//子弹的存活时间,超过后销毁自己
    
    private float clock;

    private void Update()
    {
        transform.position += velocity * speed*Time.deltaTime;
        clock += Time.deltaTime;

        if (clock >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().BeAttacked();
            Destroy(gameObject);
        }else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }

    public void Init(Vector2 target,float speed)
    {
        velocity = target - new Vector2(transform.position.x, transform.position.y);
        this.speed = speed;

        velocity.Normalize();//归一化

        float angle = Vector2.Angle(new Vector2(0, 1), velocity);

        if (velocity.x > 0)
        {
            angle *= -1;
        }
        transform.localRotation = new Quaternion(0, 0, 180f * angle,0);
    }
}
