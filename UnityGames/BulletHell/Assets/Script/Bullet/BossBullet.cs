using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    public Vector2 direction { get; set; }


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Wall")
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(direction * speed, ForceMode2D.Impulse);
            BulletPool.ReturnBullet(this);
            if(collision.tag=="Player")
            {
                collision.GetComponent<PlayerController>().Damaged(damage);
            }
        }
    }

}
