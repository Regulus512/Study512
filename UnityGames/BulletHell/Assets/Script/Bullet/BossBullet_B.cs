using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet_B : BossBullet
{
    // 초기값
    [SerializeField]
    float first_angle_itv = 0f;

    // 구불구불하게 날아가기위해 추가로회전시킬 각도
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

    void ChangeAngle() // angle_itv만큼 회전하여 진행벡터를 변경
    {
        // 진행 도중에 90도 이상 회전하지 않음
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

    void ChangeAngleDir() // 진행 각도를 반대로 변경, 회전 폭을 넓힘
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
