using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 보스가 사용할 패턴
public class Pattern : MonoBehaviour
{
    [SerializeField] protected BossController boss;
    [SerializeField] protected int bulletCount_max = 100; // 최대로 사용할 총알 수
    protected int bulletCount = 0;
    
    public virtual void Attack() { }
    public virtual void AttackEnd()
    {
        bulletCount = 0; // 총알 수 리셋
        //다음 패턴 수행
        boss.AttackEnd();
    }
}
