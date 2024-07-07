using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : SceneObject
{
    public uint partId;
    public float attackNeedSpeed;
    private Rigidbody2D _rb;

    float time ;
    public void Awake()
    {
        time = 1f;
        _rb = transform.GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if(time > 0)
            time -= Time.deltaTime;
    }
    public override void Use(GameObject gameObject)
    {
        if(time > 0)
        {
            return;
        }
        gameObject.GetComponent<Player>().AddPart(partId);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rb.velocity.magnitude < attackNeedSpeed) return;
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().BeAttacked();
        }
    }
}
