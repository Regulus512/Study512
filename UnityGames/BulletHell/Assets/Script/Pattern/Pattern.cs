using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ����� ����
public class Pattern : MonoBehaviour
{
    [SerializeField] protected BossController boss;
    [SerializeField] protected int bulletCount_max = 100; // �ִ�� ����� �Ѿ� ��
    protected int bulletCount = 0;
    
    public virtual void Attack() { }
    public virtual void AttackEnd()
    {
        bulletCount = 0; // �Ѿ� �� ����
        //���� ���� ����
        boss.AttackEnd();
    }
}
