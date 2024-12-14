using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet_A : BossBullet
{

    public void Move(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
