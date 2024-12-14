using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    int direction_y = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(0, direction_y) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            BulletPool.ReturnBullet(this);
            collision.GetComponent<BossController>().Damaged(damage);
        }
        if (collision.tag == "Wall")
        {
            BulletPool.ReturnBullet(this);
        }
    }
}
