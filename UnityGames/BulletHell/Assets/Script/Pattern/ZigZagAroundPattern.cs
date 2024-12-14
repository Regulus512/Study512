using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagAroundPattern : Pattern
{
    [SerializeField] float bullet_itv = 0.2f; // ���� ���� ������ ���� �Ѿ��� ����������� ����

    [SerializeField] private float m_viewRadius = 1f; // ray ����

    [Range(0f, 360f)]
    [SerializeField] private float viewAngle = 0f; // ��ä���� ����
    // �������� �߻� ���͸� ȸ����ų �ִ� ����
    [SerializeField] private float angleChangeMax = 0f;
    
    [SerializeField] private float angleChange = 0.001f;// ȸ�� ����(����)
    [SerializeField] float angleChange_itv = 0.01f; // ȸ�� ����(��)

    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ = 0f;

    private float viewHalfAngle = 0f;

    [Range(1, 10)]
    [SerializeField] int Count = 5; // �� ������ �Ѿ��� ���� (Count+1)
    float angleOffset = 0f; // ������ ������ ����(degree)

    // �Ѿ� ���� ��ġ
    [SerializeField] Transform[] bulletspawnPos;

    private void Awake()
    {
        viewHalfAngle = viewAngle * 0.5f;
        angleOffset = viewAngle / Count;
    }
    public override void Attack()
    {
        Debug.Log(this.name + "Attack Start");
        FireAll();
        StartCoroutine(AngleMoveLeft());
    }

    public override void AttackEnd()
    {
        Debug.Log(this.name + "Attack End");
        CancelInvoke();
        StopAllCoroutines();
        base.AttackEnd();
    }

    // ��� �߻�
    void FireAll()
    {
        if (bulletCount > bulletCount_max)
        {
            AttackEnd();
            return;
        }
        for (int i = 0; i < bulletspawnPos.Length; i++)
        {
            // ��ä�� ���·� ȸ���ϸ� �߻�
            for (int j = 0; j <= Count; j++)
            {
                Fire(i, viewHalfAngle + m_viewRotateZ - angleOffset * j);
            }
        }
        
        Invoke("FireAll", bullet_itv);
    }

    // �� �� �߻�
    void Fire(int spawnPos_index,float angle)
    {
        bulletCount++;
        //Debug.Log("Fire angle: " + angle);
        Vector2 dir = AngleToDirZ(angle);
        Bullet bullet = BulletPool.GetBullet(eBulletType.BOSS_BULLET_B);
        bullet.transform.position = bulletspawnPos[spawnPos_index].position;

        // ���� ȸ�� ���� - angle
        // ���ʺ��� ���������� �׷��ֹǷ� -
        bullet.transform.rotation = Quaternion.AngleAxis(boss.lookAngle - 270f - angle, Vector3.forward);
        bullet.GetComponent<BossBullet_B>().Move(dir.normalized);
    }
    
    

    // �ڷ�ƾ���� �߻簢�� �����ֱ�
    IEnumerator AngleMoveLeft()
    {
        //Debug.Log("AngleMoveLeft");
        while (m_viewRotateZ > -angleChangeMax)
        {
            m_viewRotateZ -= angleChange;
            yield return new WaitForSeconds(angleChange_itv);
        }
        StartCoroutine(AngleMoveRight());
    }
    IEnumerator AngleMoveRight()
    {
        //Debug.Log("AngleMoveRight");
        while (m_viewRotateZ < angleChangeMax)
        {
            m_viewRotateZ += angleChange;
            yield return new WaitForSeconds(angleChange_itv);
        }
        StartCoroutine(AngleMoveLeft());
    }

    // ��ä���� �Ѿ� �߻� ����
    // �Է��� -180~180�� ���� Up Vector ���� Local Direction���� ��ȯ������.
    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0f);
    }

    // �ʱ� �Ѿ� ���� �׷��ֱ�
    private void OnDrawGizmos()
    {
        viewHalfAngle = viewAngle * 0.5f;

        
        // ����Ƽ ���Ϸ����� ����� �������� ȸ��, ������ �������� ȸ����
        // ������ ��(right)�� �������
        // ����(���) ������(����)
        for(int i = 0; i < bulletspawnPos.Length; i++)
        {
            // ����
            Debug.DrawRay(bulletspawnPos[i].position,
                AngleToDirZ(viewHalfAngle + m_viewRotateZ) * m_viewRadius, Color.white);
            // ������
            Debug.DrawRay(bulletspawnPos[i].position,
                    AngleToDirZ(-viewHalfAngle + m_viewRotateZ) * m_viewRadius, Color.white);
        }
    }
    
}
