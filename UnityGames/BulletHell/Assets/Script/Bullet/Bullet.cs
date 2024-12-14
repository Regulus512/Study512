using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 어떤 종류의 총알인지 확인
// 오브젝트풀에서 총알을 가져올 때 어느 종류의 큐에서 가져올 지 확인
public enum eBulletType
{
    PLAYER_BULLET, BOSS_BULLET_A, BOSS_BULLET_B, BOSS_BULLET_C
}

public class Bullet : MonoBehaviour
{
    [SerializeField] eBulletType bulletType = eBulletType.PLAYER_BULLET;
    [SerializeField] protected float speed = 3.0f;
    [SerializeField] protected Rigidbody2D rigid;
    
    // 총알에 맞았을 때 데미지
    [SerializeField] protected int damage = 1; 

    public eBulletType getBulletType() { return bulletType; }

    public virtual void InitBullet() { }
}
