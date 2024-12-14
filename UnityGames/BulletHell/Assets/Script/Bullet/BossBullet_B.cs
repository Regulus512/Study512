using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet_B : BossBullet
{
    // �ʱⰪ
    [SerializeField]
    float first_angle_itv = 0f;

    // ���ұ����ϰ� ���ư������� �߰���ȸ����ų ����
    float zigzagAngle = 1f;
    float angle_itv = 2f;

    [SerializeField] float change_itv = 0.1f;
    [SerializeField] float change_dir_itv = 1f;

    public override void InitBullet()
    {
        angle_itv = first_angle_itv;
    }
    public void Move(Vector2 dir)//, Vector2 changeDir)
    {
        zigzagAngle = angle_itv;
        rigid.AddForce(dir * speed, ForceMode2D.Impulse);
        Invoke("ChangeAngleDir", change_dir_itv);
        Invoke("ChangeAngle", change_itv);
    }

    void ChangeAngle() // angle_itv��ŭ ȸ���Ͽ� ���຤�͸� ����
    {
        // ���� ���߿� 90�� �̻� ȸ������ ����
        float angle = zigzagAngle + angle_itv;
        if (0f < angle && angle < 90f ||
            0f > angle && angle > -90f)
        {
            zigzagAngle += angle_itv;
        }
        direction = AngleToDirZ(zigzagAngle);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
        Invoke("ChangeAngle", change_itv);
    }

    void ChangeAngleDir() // ���� ������ �ݴ�� ����, ȸ�� ���� ����
    {
        angle_itv = first_angle_itv * -1;
        if (angle_itv > 0 &&
            (0f < zigzagAngle && zigzagAngle < 45f ||
            0f > zigzagAngle && zigzagAngle > -45f))
        {
            angle_itv *= 1.5f;
        }
        Invoke("ChangeAngleDir", change_dir_itv);
    }


    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0f);
    }
    //private void OnDrawGizmos()
    //{
        //Debug.DrawRay(transform.position, direction * 5, Color.blue);
    //}
}
