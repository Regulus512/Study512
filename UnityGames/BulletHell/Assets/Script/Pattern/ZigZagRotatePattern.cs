using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagRotatePattern : Pattern
{
    [SerializeField] float bullet_itv = 0.2f; // 같은 패턴 내에서 다음 총알이 나오기까지의 간격

    [Range(0f, 360f)]
    [SerializeField] private float viewAngle = 0f; // 부채꼴의 각도

    [SerializeField] private float angleChange = 0.01f;// 회전 간격(각도)
    [SerializeField] float angleChange_itv = 0.001f; // 회전 간격(초)

    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ = 0f;

    private float viewHalfAngle = 0f;

    [Range(1, 10)]
    [SerializeField] int Count = 5; // 몇 방향의 총알을 쏠지 (Count+1)
    float angleOffset = 0f; // 방향을 결정할 간격(degree)

    // 총알 스폰 위치
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
        int dir = Random.Range(0, 2);
        if(dir == 0)
        {
            StartCoroutine(AngleMoveLeft());
        }
        else if(dir == 1)
        {
            StartCoroutine(AngleMoveRight());
        }
    }

    public override void AttackEnd()
    {
        Debug.Log(this.name + "Attack End");
        m_viewRotateZ = 0;
        CancelInvoke();
        StopAllCoroutines();
        base.AttackEnd();
    }

    // 모두 발사
    void FireAll()
    {
        if (bulletCount > bulletCount_max)
        {
            AttackEnd();
            return;
        }
        for (int i = 0; i < bulletspawnPos.Length; i++)
        {
            // 부채꼴 형태로 회전하며 발사
            for (int j = 0; j <= Count; j++)
            {
                Fire(i, viewHalfAngle + m_viewRotateZ - angleOffset * j);
            }
        }

        Invoke("FireAll", bullet_itv);
    }

    // 한 발 발사
    void Fire(int spawnPos_index, float angle)
    {
        bulletCount++;
        //Debug.Log("Fire angle: " + angle);
        Vector2 dir = AngleToDirZ(angle);
        Bullet bullet = BulletPool.GetBullet(eBulletType.BOSS_BULLET_C);
        bullet.transform.position = bulletspawnPos[spawnPos_index].position;

        // 보스 회전 각도 - angle
        // 왼쪽부터 오른쪽으로 그려주므로 -
        bullet.transform.rotation = Quaternion.AngleAxis(270f - angle, Vector3.forward);
        bullet.GetComponent<BossBullet_B>().Move(dir.normalized);
    }



    // 코루틴으로 발사각도 흔들어주기
    IEnumerator AngleMoveLeft()
    {
        //Debug.Log("AngleMoveLeft");
        while (m_viewRotateZ > -360)
        {
            m_viewRotateZ -= angleChange;
            yield return new WaitForSeconds(angleChange_itv);
        }
        m_viewRotateZ = 0;
        StartCoroutine(AngleMoveLeft());
    }
    IEnumerator AngleMoveRight()
    {
        //Debug.Log("AngleMoveRight");
        while (m_viewRotateZ < 360)
        {
            m_viewRotateZ += angleChange;
            yield return new WaitForSeconds(angleChange_itv);
        }
        m_viewRotateZ = 0;
        StartCoroutine(AngleMoveRight());
    }

    // 부채꼴형 총알 발사 각도
    // 입력한 -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0f);
    }
}
