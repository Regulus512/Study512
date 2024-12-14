using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// � ������ �Ѿ����� Ȯ��
// ������ƮǮ���� �Ѿ��� ������ �� ��� ������ ť���� ������ �� Ȯ��
public enum eBulletType
{
    PLAYER_BULLET, BOSS_BULLET_A, BOSS_BULLET_B, BOSS_BULLET_C
}

public class Bullet : MonoBehaviour
{
    [SerializeField] eBulletType bulletType = eBulletType.PLAYER_BULLET;
    [SerializeField] protected float speed = 3.0f;
    [SerializeField] protected Rigidbody2D rigid;
    
    // �Ѿ˿� �¾��� �� ������
    [SerializeField] protected int damage = 1; 

    public eBulletType getBulletType() { return bulletType; }

    public virtual void InitBullet() { }
}
