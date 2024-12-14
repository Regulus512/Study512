using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAroundPattern : Pattern
{
    [SerializeField] Transform target = null; // �÷��̾� �ǽð� ��ġ

    [SerializeField] float bulletspeed = 2.0f;

    [SerializeField] float bullet_itv = 1.0f; // ���� ���� ������ ���� �Ѿ��� ����������� ����

    [SerializeField] private bool m_bDebugMode = false; // ray�� ǥ�� �ɼ�
    [SerializeField] private float m_viewRadius = 1f; // ray ����

    [Range(0f, 360f)]
    [SerializeField] private float viewAngle = 0f; // ��ä���� ����

    
    
    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ = 0f;

    private float viewHalfAngle = 0f;

    [SerializeField] int Count = 5; // �� ������ �Ѿ��� ���� (Count+1)
    float angleOffset = 0f; // ������ ������ ����(degree)

    private void Awake()
    {
        viewHalfAngle = viewAngle * 0.5f;
        angleOffset = viewAngle / Count;
    }
    public override void Attack()
    {
        //Debug.Log(this.name + "Attack Start");
        FireAll();
    }
    public override void AttackEnd()
    {
        //Debug.Log(this.name + "Attack End");
        CancelInvoke();
        base.AttackEnd();
    }
    void FireAll()
    {
        if(bulletCount > bulletCount_max)
        {
            AttackEnd();
            return;
        }
        // ��ä�� ���·� ȸ���ϸ� �߻�
        for (int i = 0; i <= Count; i++)
        {
            Fire(viewHalfAngle + m_viewRotateZ - angleOffset * i);
        }
        Invoke("FireAll", bullet_itv);
    }
    void Fire(float angle)
    {
        bulletCount++;
        //Debug.Log("Fire angle: " + angle);
        Vector2 dir = AngleToDirZ(angle);
        Bullet bullet = BulletPool.GetBullet(eBulletType.BOSS_BULLET_A);
        if(bullet.gameObject == null)
        {
            Debug.Log("null bullet!");
        }
        bullet.transform.position = transform.position;
        
        // ȸ���� ���� ������Ʈ�� ���� - angle
        // ���ʺ��� ���������� �׷��ֹǷ� -����
        bullet.transform.rotation = Quaternion.AngleAxis(boss.lookAngle - 270f - angle, Vector3.forward);
        bullet.GetComponent<BossBullet>().direction = dir;
        bullet.GetComponent<BossBullet_A>().Move(dir);

    }

    // ��ä���� �Ѿ� �߻�
    // �Է��� -180~180�� ���� Up Vector ���� Local Direction���� ��ȯ������.
    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0f);
    }
    private void OnDrawGizmos()
    {
        if (m_bDebugMode)
        {
            viewHalfAngle = viewAngle * 0.5f;

            Vector3 originPos = transform.position;

            // ����Ƽ ���Ϸ����� ����� �������� ȸ��, ������ �������� ȸ����
            // ������ ��(right)�� �������
            // ����(���) ������(����)
            Vector3 leftDir = AngleToDirZ(viewHalfAngle + m_viewRotateZ);
            Vector3 rightDir = AngleToDirZ(-viewHalfAngle + m_viewRotateZ);
            Vector3 lookDir = AngleToDirZ(m_viewRotateZ);


            // ���ʿ������� Count��ŭ ������ ���������� ������(angleOffset) ray�� �׸�
            for(int i = 0; i < Count; i++)
            {
                Debug.DrawRay(originPos,
                    AngleToDirZ(viewHalfAngle + m_viewRotateZ - angleOffset * i)
                    * m_viewRadius, Color.green);
            }

            Debug.DrawRay(originPos, leftDir * m_viewRadius, Color.cyan);
            Debug.DrawRay(originPos, lookDir * m_viewRadius, Color.green);
            Debug.DrawRay(originPos, rightDir * m_viewRadius, Color.cyan);
        }
    }
}
