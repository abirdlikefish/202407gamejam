using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[HideInInspector] public Vector3 velocity;//�ӵ��ķ����ٶ�
    //[Header("�ӵ��ķ�������")] public float speed;//�ӵ��ķ�������
    private float speed;
    [Header("�ӵ��Ĵ��ʱ��")] public float lifeTime;//�ӵ��Ĵ��ʱ��,�����������Լ�

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

    private void OnTriggerEnter2D(Collider2D other)
    {
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
