using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAroundPattern : Pattern
{
    [SerializeField] Transform target = null; // 플레이어 실시간 위치

    [SerializeField] float bulletspeed = 2.0f;

    [SerializeField] float bullet_itv = 1.0f; // 같은 패턴 내에서 다음 총알이 나오기까지의 간격

    [SerializeField] private bool m_bDebugMode = false; // ray를 표시 옵션
    [SerializeField] private float m_viewRadius = 1f; // ray 길이

    [Range(0f, 360f)]
    [SerializeField] private float viewAngle = 0f; // 부채꼴의 각도

    
    
    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ = 0f;

    private float viewHalfAngle = 0f;

    [SerializeField] int Count = 5; // 몇 방향의 총알을 쏠지 (Count+1)
    float angleOffset = 0f; // 방향을 결정할 간격(degree)

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
        // 부채꼴 형태로 회전하며 발사
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
        
        // 회전한 보스 오브젝트의 각도 - angle
        // 왼쪽부터 오른쪽으로 그려주므로 -해줌
        bullet.transform.rotation = Quaternion.AngleAxis(boss.lookAngle - 270f - angle, Vector3.forward);
        bullet.GetComponent<BossBullet>().direction = dir;
        bullet.GetComponent<BossBullet_A>().Move(dir);

    }

    // 부채꼴형 총알 발사
    // 입력한 -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
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

            // 유니티 오일러각은 양수가 좌측으로 회전, 음수가 우측으로 회전함
            // 오른쪽 각(right)은 역수사용
            // 왼쪽(양수) 오른쪽(음수)
            Vector3 leftDir = AngleToDirZ(viewHalfAngle + m_viewRotateZ);
            Vector3 rightDir = AngleToDirZ(-viewHalfAngle + m_viewRotateZ);
            Vector3 lookDir = AngleToDirZ(m_viewRotateZ);


            // 왼쪽에서부터 Count만큼 각도를 오른쪽으로 보내며(angleOffset) ray를 그림
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
